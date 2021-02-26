using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty().MinimumLength(2);
            RuleFor(u => u.Password).NotEmpty().MinimumLength(6);
            RuleFor(u => u.Email).NotEmpty().MinimumLength(5).Must(HaveToIncludeChar).WithMessage("@ karakteri içermeyen email girdiniz!");
        }

        private bool HaveToIncludeChar(string arg)
        {
            return arg.Contains("@");
        }
    }
}
