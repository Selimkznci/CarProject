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
       

        public List<CarDetailDto> GetCarDetails()
        {

            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var results = from car in context.cars
                              join col in context.colors on car.ColorId equals col.Id
                              join br in context.brands on car.BrandId equals br.Id
                              select new CarDetailDto
                              {
                                  CarName = car.Descriptions,
                                  BrandName = br.BrandName,
                                  ColorName = col.ColorName,
                                  DailyPrice = car.DailyPrice
                              };
                return results.ToList();

            }
        }

   
   }
}
