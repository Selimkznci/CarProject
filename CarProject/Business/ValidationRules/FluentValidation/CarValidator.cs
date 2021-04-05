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
            RuleFor(c => c.Descriptions).NotEmpty(); // Boş geçilemez
            RuleFor(c => c.Descriptions).MinimumLength(5); // En Az 5 Karakter
            RuleFor(c => c.DailyPrice).GreaterThan(0).NotEmpty(); //1.0'dan Daha büyük  2.//Fiyatı Boş olamaz
        }
    }
}
