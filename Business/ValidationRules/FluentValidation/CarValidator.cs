using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty().GreaterThan(0);
            RuleFor(c => c.ModelYear).NotEmpty().GreaterThan(2000).LessThan(DateTime.Now.Year).WithMessage("Arabalar 2000 ile "+ DateTime.Now.Year + " model arası olmalıdır!" );
            RuleFor(c => c.Description).NotEmpty().WithMessage("Açıklama zorunludur!");
            RuleFor(c => c.Description).MinimumLength(3);
        }
    }
}
