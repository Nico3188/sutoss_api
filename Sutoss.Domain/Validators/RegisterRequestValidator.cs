using FluentValidation;
using Sutoss.Domain.Services.Domain.Request;
using System;

namespace Sutoss.Domain.Services.Domain.Validators
{

    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //RuleFor(x => x.FirstName).NotNull();
            //RuleFor(x => x.LastName).NotNull();
            //RuleFor(x => x.UserName).NotNull().Length(3, 25);
            RuleFor(x => x.Email).NotNull().EmailAddress();
            //RuleFor(x => x.Password).NotNull().Length(8, 25);
            //RuleFor(x => x.Cbu).NotNull().Length(20, 22);
            //RuleFor(x => x.Birthdate).NotNull();
        }
    }
}
