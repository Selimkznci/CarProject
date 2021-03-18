using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EfEntityRepositoryBase<Car, MyDatabaseContext>, ICarDal
    {
        public new void Add(Car entity)
        {
            if (CheckToAdd(entity))
            {
                using (MyDatabaseContext context = new MyDatabaseContext())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("ARABA EKLENEMEDİ");
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var results = from car in context.cars
                              join col in context.colors on car.ColorId equals col.Id
                              join br in context.brands on car.BrandId equals br.Id
                              select new CarDetailDto
                              {
                                  CarName = car.Description,
                                  BrandName = br.BrandName,
                                  ColorName = col.ColorName,
                                  DailyPrice = car.DailyPrice
                              };
                return results.ToList();

            }
        }

        public bool CheckToAdd(Car entity)
        {
            if (entity.Description.Length >= 2 && entity.DailyPrice > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
