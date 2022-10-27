using sutoss.Domain.Services;
using sutoss.Domain.Services.Domain.Repositories;
using sutoss.Domain.Services.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using sutoss.Domain.Services.Helpers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Domain.Services.Interfaces;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace sutoss.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSystem(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<DomainSettings>(config);
        }

        public static void ConfigureRepos(this IServiceCollection services)
        {
            services.AddScoped<IBundleRepository, BundleRepository>();
            services.AddScoped<IHealtcareVisitDocumentRepository, HealtcareVisitDocumentRepository>();
            services.AddScoped<IHealtcareVisitDocumentTypeRepository, HealtcareVisitDocumentTypeRepository>();
            services.AddScoped<IHealtcareVisitProgressRepository, HealtcareVisitProgressRepository>();
            services.AddScoped<IHealtcareVisitRepository, HealtcareVisitRepository>();
            services.AddScoped<IHealtcareVisitTypeRepository, HealtcareVisitTypeRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetServiceRepository, PetServiceRepository>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IRefundRepository, RefundRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IServiceItemRepository, ServiceItemRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        }

        public static void ConfigureInnerServices(this IServiceCollection services)
        {
            services.AddScoped<IBundlesService, BundlesService>();
            services.AddScoped<IHealtcareVisitDocumentsService, HealtcareVisitDocumentsService>();
            services.AddScoped<IHealtcareVisitDocumentTypesService, HealtcareVisitDocumentTypesService>();
            services.AddScoped<IHealtcareVisitProgressesService, HealtcareVisitProgressesService>();
            services.AddScoped<IHealtcareVisitsService, HealtcareVisitsService>();
            services.AddScoped<IHealtcareVisitTypesService, HealtcareVisitTypesService>();
            services.AddScoped<IOwnersService, OwnersService>();
            services.AddScoped<IPaymentsService, PaymentsService>();
            services.AddScoped<IPetsService, PetsService>();
            services.AddScoped<IPetServicesService, PetServicesService>();
            services.AddScoped<IPetTypesService, PetTypesService>();
            services.AddScoped<IRefundsService, RefundsService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IServiceItemsService, ServiceItemsService>();
            services.AddScoped<IServicesService, ServicesService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IUserRolesService, UserRolesService>();
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });
        }

        public static void ConfigureAuth0Authorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ClientRole", policy => policy.RequireClaim("DracosutossRoles", "client"));
            });
        }

        public static void ConfigureAuth0Authetication(this IServiceCollection services)
        {
            services.AddAuthorization(
                options =>
            {
                options.AddPolicy("ClientRole", policy => policy.RequireClaim("DracosutossRoles", "client"));
            }
            );
        }

        public static void ConfigureAuth0Authetication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = $"https://dev-x1-1jwqn.us.auth0.com/";
                options.Audience = "rlL1xv9pEH1RsbhzrttNiuo61Td4ZPHq";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = ClaimTypes.NameIdentifier
                };
                options.Events = new JwtBearerEvents()
                {
                    OnTokenValidated = context =>
                    {
                        if (!(context.SecurityToken is JwtSecurityToken token)) return Task.CompletedTask;
                        if (context.Principal?.Identity is ClaimsIdentity identity)
                        {
                            identity.AddClaim(new Claim("access_token", token.RawData));
                        }
                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine(context.Exception.Message);
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        Console.WriteLine(context.ToString());
                        return Task.CompletedTask;
                    }
                    
                };

            });
        }
    }
}
