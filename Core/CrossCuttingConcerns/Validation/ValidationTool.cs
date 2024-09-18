using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        //burada büyük bir hata yazılmıştı düzelttim result.IsValid yerine result==null gibi bir ifade vardı
        public static void Validate(IValidator validator, object entity)
        {

            var context = new ValidationContext<object>(entity);  

            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                    throw new ValidationException(result.Errors);
            }
        }
    }
}
