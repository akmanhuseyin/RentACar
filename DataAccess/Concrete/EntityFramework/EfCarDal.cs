using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DbRentACarContext>, ICarDal
    {
        public CarDetailDto GetCarDetail(int carId)
        {
            using (DbRentACarContext context = new DbRentACarContext())
            {
                var result = from p in context.Cars.Where(p => p.Id == carId)
                             join c in context.Colors
                             on p.ColorId equals c.ColorId
                             join d in context.Brands
                             on p.BrandId equals d.BrandId
                             select new CarDetailDto
                             {
                                 BrandName = d.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = p.DailyPrice,
                                 Description = p.Description,
                                 ModelYear = p.ModelYear,
                                 Id = p.Id,
                                 Status = !context.Rentals.Any(p => p.CarId == carId && p.ReturnDate == null)
                             };
                return result.SingleOrDefault();
            }
        }
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (DbRentACarContext context = new DbRentACarContext())
            {
                var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join clr in context.Colors
                             on c.ColorId equals clr.ColorId                             
                             select new CarDetailDto { Id = c.Id, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description, BrandName = b.BrandName, ColorName = clr.ColorName, BrandId = b.BrandId, ColorId= c.ColorId };
                return result.ToList();
            }
        }
    }
}
