using Core.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("İsim boş olamaz.");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyisim boş olamaz.");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email boş olamaz.");
            //RuleFor(u => u.Email).EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");


        }
    }
}
