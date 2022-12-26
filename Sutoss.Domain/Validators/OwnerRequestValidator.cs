using FluentValidation;
using Sutoss.Domain.Services.Domain.Request;
using System;

namespace Sutoss.Domain.Services.Domain.Validators
{

    public class OwnerRequestValidator : AbstractValidator<OwnerRequest>
    {
        public OwnerRequestValidator()
        {
            RuleFor(x => x.FirstName).NotNull();
            RuleFor(x => x.LastName).NotNull();
            RuleFor(x => x.Cbu).NotNull().Length(20, 22);
            RuleFor(x => x.Birthdate).NotNull();
            RuleFor(x => HasLegalAge(x.Birthdate)).Equal(true);
        }

        bool HasLegalAge(DateTime bornDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bornDate.Year;
            if (age > 18)
                return true;
            
            if (age == 18)
            {
                if (today.Month > bornDate.Month)
                    return true;
                else if (today.Month == bornDate.Month)
                {
                    return today.Day >= bornDate.Day; 
                }
                else
                    return false;
            }

            return false;
        }
    }
}
