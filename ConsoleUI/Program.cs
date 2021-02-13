using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //customerManager.Add(new Entities.Concrete.Customer() { CompanyName = "SunExpress" });


            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var addResult = rentalManager.Add(new Rental() { CarId = 3, CustomerId = 1, RentDate = DateTime.Now });

            //if (addResult.Success)
            //{
            //    foreach (var item in rentalManager.GetAll().Data)
            //    {
            //        Console.WriteLine(item.CarId + "\t --- \t" + item.CustomerId);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(addResult.Message);
            //}
            rentalManager.GetById(1).Data.


            //CarTest();

            //ColorTest();

            //BrandTest();

            //CarManager carManager = new CarManager(new EfCarDal());
            //var result = carManager.GetCarDetail();
            //if (result.Success)
            //{
            //    foreach (var item in result.Data)
            //    {
            //        Console.WriteLine("{0} *** {1} *** {2}", item.BrandName, item.ColorName, item.Description);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.ColorName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine("{0} | {1} | {2} TL", item.Description, item.ModelYear, item.DailyPrice);
            }
        }
    }
}
