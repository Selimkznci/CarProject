using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalListed);
            }
            return new ErrorResult(Messages.RentalNotListed);
        }

        public IResult CheckReturnDate(int carId)
        {

            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult UpdateReturnDate(Rental rental)
        {
            var result = _rentalDal.GetAll(r => r.Id == rental.Id);
            var updateRental = result.LastOrDefault();
            if (updateRental.ReturnDate != null)
            {
                return new ErrorResult(Messages.RentalUpdateReturnDateError);
            }
            updateRental.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(updateRental);
            return new SuccessResult(Messages.RentalUpdateReturnDate);
        }
    }
}
