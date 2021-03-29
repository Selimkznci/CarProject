using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty(); // Boş geçilemez
            RuleFor(c => c.Description).MinimumLength(5); // En Az 5 Karakter
            RuleFor(c => c.DailyPrice).GreaterThan(0).NotEmpty(); //1.0'dan Daha büyük  2.//Fiyatı Boş olamaz
            RuleFor(c => c.ModelYear).Must(StartWith1); 
        }

        private bool StartWith1(string arg)
        {
            return arg.StartsWith("1,2");
        }
    }
}
