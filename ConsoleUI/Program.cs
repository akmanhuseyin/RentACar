using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //ColorTest();

            //BrandTest();

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetail();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine("{0} *** {1} *** {2}", item.BrandName, item.ColorName, item.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
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
