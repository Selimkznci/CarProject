using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using Entities.Concrete;
using System.Collections.Generic;
using System.Text;
using DataAccess.Concrete.EntityFramework;
using Business.Abstract;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~ MERHABA! KAZANCI OTO KİRALAMA ~~~~~~");
         //   CarTest();

          //  ColorTest();

           // BrandTest();

            CarDetailsTest();

            //UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User() { FirstName = "Selim", LastName = "Kazancı", Email = "selimkznci@gmail.com", Password = "129" });
            //userManager.Add(new User() { FirstName = "Ahmet", LastName = "Tüfenkci", Email = "ahmotufek@hotmail.com", Password = "954" });
            //userManager.Add(new User() { FirstName = "Mehmet", LastName = "Yağcı", Email = "yagcıoglu@outlook.com", Password = "456" });

            //Console.WriteLine("---> Bütün kullanıcılar <---");
            //foreach (var item in userManager.GetAll().Data)
            //{
            //    Console.WriteLine("Id:" + item.Id + "  FirstName:" + item.FirstName + "  LastName:" + item.LastName);
            //}

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer() { UserId = 1, CompanyName = "Kazancı Hol" });
            customerManager.Add(new Customer() { UserId = 2, CompanyName = "Sezallar" });
            Console.WriteLine("Bütün Müşteriler .......");
            foreach (var item in customerManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.UserId + "  CompanyName:" + item.CompanyName);
            }


        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("CarName :" + item.CarName + "  BrandName:" + item.BrandName + "  ColorName:" + item.ColorName + "  DailyPrice:" + item.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand() {  BrandName = "mercedes" });
            brandManager.Add(new Brand() {  BrandName = "bmw" });
            brandManager.Add(new Brand() { BrandName = "audi" });

            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.BrandName);
            }

            //brandManager.Delete(new Brand() { Id = 2, BrandName = "bmw" });
            //foreach (var item in brandManager.GetAll().Data)
            //{
            //    Console.WriteLine("Id:" + item.Id + "  Name:" + item.BrandName);
            //}

            //brandManager.Update(new Brand() { Id = 3, BrandName = "toyota" });
            //Console.WriteLine("3 nolu marka değiştirilmiştir");
            //Console.WriteLine("Id:" + brandManager.GetById(3).Data.Id + "  Name:" + brandManager.GetById(3).Data.BrandName);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new Business.Concrete.ColorManager(new EfColorDal());
            colorManager.Add(new Color() {  ColorName = "kırmızı" });
            colorManager.Add(new Color() {  ColorName = "mavi" });
            colorManager.Add(new Color() { ColorName = "siyah" });

            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.Id + "  Name:" + item.ColorName);
            }

            //colorManager.Delete(new Color() { Id = 2, ColorName = "mavi" });
            //foreach (var item in colorManager.GetAll().Data)
            //{
            //    Console.WriteLine("Id:" + item.Id + "  Name:" + item.ColorName);
            //}

            //colorManager.Update(new Color() { Id = 3, ColorName = "mavi" });
            //Console.WriteLine("3 nolu color değiştirilmiştir");
            //Console.WriteLine("Id:" + colorManager.GetById(3).Data.Id + "  Name:" + colorManager.GetById(3).Data.ColorName);
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car() { BrandId = 1, ColorId = 1, DailyPrice = 90, ModelYear = "2005", Description = "Hısım" });
            Listele(carManager);
            Console.WriteLine("nolu markanın arabaları aşağıdadır");
            foreach (var item in carManager.GetCarsByBrandId(5).Data)
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
                    ;
            Console.WriteLine("2 nolu rengin arabaları aşağıdadır");
            foreach (var item in carManager.GetCarsByColorId(2).Data)
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
        }

        private static void Listele(CarManager carManager)
        {
            Console.WriteLine("------");
            foreach (var item in carManager.GetAll().Data)
            {
                Console.WriteLine("Id:" + item.Id + "   BrandId:" + item.BrandId + "   ColorId:" + item.ColorId + "   DailyPrice:" + item.DailyPrice + "  Description:" + item.Description + "  ModelYear:" + item.ModelYear);
            }
        }
    }
}

