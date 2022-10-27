using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using sutoss.Domain.Services.Domain.Request;
using sutoss.Domain.Services.Domain.Validators;

namespace sutoss.Extensions
{
    public static class ValidatorExtensions
    {
        public static void ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
        }
    }
}
