using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _carDal;
        public InMemoryCarDal()
        {
          //  _carDal = new List<Car> { new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 70, ModelYear = new DateTime(1998, 01, 01), Description = "Audi" } };
            //_carDal = new List<Car> { new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 90, ModelYear = new DateTime(2001, 01, 01), Description = "Opel" } };
            //_carDal = new List<Car> { new Car { Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 150, ModelYear = new DateTime(2010, 01, 01), Description = "Mercedes" } };
            //_carDal = new List<Car> { new Car { Id = 4, BrandId = 4, ColorId = 4, DailyPrice = 200, ModelYear = new DateTime(2020, 01, 01), Description = "Honda" } };
            //_carDal = new List<Car> { new Car { Id = 5, BrandId = 5, ColorId = 5, DailyPrice = 100, ModelYear=new DateTime(2005,01,01), Description = "Bmw" } };
        }
        public void Add(Car car)
        {
             _carDal.Add(car);
        }

        public bool CheckToAdd(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car CarToDelete = null;

             CarToDelete = _carDal.SingleOrDefault(c => c.Id == c.Id);
            _carDal.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrand(int brandId)
        {
            return _carDal.Where(c => c.BrandId == c.BrandId).ToList();
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car CarToUpdate = null;
            CarToUpdate = _carDal.SingleOrDefault(c => c.Id == c.Id);
            CarToUpdate.Description = car.Description;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
