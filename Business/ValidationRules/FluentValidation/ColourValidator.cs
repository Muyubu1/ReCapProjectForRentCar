using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColourValidator : AbstractValidator<Colour>
    {
        public ColourValidator()
        {
            // ColorName alanı boş olamaz ve en az 3 karakter uzunluğunda olmalı.
            RuleFor(c => c.ColourName).NotEmpty();
            RuleFor(c => c.ColourName).MinimumLength(1);
        }
    }
}