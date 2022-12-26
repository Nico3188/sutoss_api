using Sutoss.Domain.Services;
using Sutoss.Domain.Services.Domain.Repositories;
using Sutoss.Domain.Services.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Sutoss.Domain.Services.Helpers;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Sutoss.Domain.Services.Domain.Repositories.Interfaces;
using Sutoss.Domain.Services.Domain.Services.Interfaces;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace Sutoss.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSystem(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<DomainSettings>(config);
        }

        public static void ConfigureRepos(this IServiceCollection services)
        {
            services.AddScoped<IProvinciumRepository, ProvinciumRepository>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<ILocalidadRepository, LocalidadRepository>();
            services.AddScoped<IInstalacionRepository, InstalacionRepository>();
            services.AddScoped<IAlquilerRepository, AlquilerRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<ICheckxcontratoRepository,CheckxcontratoRepository>();
            services.AddScoped<ICheklistRepository, CheklistRepository>();
            services.AddScoped<IMultaxcontratoRepository, MultaxcontratoRepository>();
            services.AddScoped<IMultumRepository, MultumRepository>();
            services.AddScoped<IFpContratoRepository,FpContratoRepository>();
            services.AddScoped<IFormaPagoRepository, FormaPagoRepository>();
            services.AddScoped<IPrestamoRepository, PrestamoRepository>();
            services.AddScoped<IPrestamosxpersonaRepository, PrestamosxpersonaRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<ICelebracionRepository, CelebracionRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IGanadorRepository, GanadorRepository>();
            services.AddScoped<IPremioRepository, PremioRepository>();
            services.AddScoped<ISuscripcionRepository, SuscripcionRepository>();
            services.AddScoped<IBeneficioRepository, BeneficioRepository>();
            services.AddScoped<IDesignacionRepository, DesignacionRepository>();
            services.AddScoped<ITurnoRepository, TurnoRepository>();
            services.AddScoped<IImpxinstalacionRepository, ImpxinstalacionRepository>();
            services.AddScoped<IImpuestoRepository,ImpuestoRepository>();
            services.AddScoped<IGastoxinstRepository, GastoxinstRepository>();
            services.AddScoped<IGastoRepository, GastoRepository>();
            services.AddScoped<IProductoAsignadoRepository, ProductoAsignadoRepository>();
            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IPedidoProductoRepository, PedidoProductoRepository>();
            services.AddScoped<IOrdenCompraRepository, OrdenCompraRepository>();
            services.AddScoped<IDetalleCompraRepository, DetalleCompraRepository>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();
            services.AddScoped<IDetalleFacturaRepository, DetalleFacturaRepository>();
            services.AddScoped<IMantenimientoRepository, MantenimientoRepository>();
            services.AddScoped<IDetalleMantenimientoRepository, DetalleMantenimientoRepository>();
            services.AddScoped<IServicioRepository,ServicioRepository>();
            services.AddScoped<IProveedorRepository, ProveedorRepository>();
            services.AddScoped<IOrdenPagoRepository, OrdenPagoRepository>();
        }
        public static void ConfigureInnerServices(this IServiceCollection services)
        {
            services.AddScoped<IProvinciaService, ProvinciaService>();
            services.AddScoped<IDepartamentosService, DepartamentosService>();
            services.AddScoped<ILocalidadsService, LocalidadsService>();
            services.AddScoped<IInstalacionsService, InstalacionsService>();
            services.AddScoped<IAlquilersService,AlquilersService>();
            services.AddScoped<IContratosService, ContratosService>();
            services.AddScoped<ICheckxcontratosService, CheckxcontratosService>();
            services.AddScoped<ICheklistsService, CheklistsService>();
            services.AddScoped<IMultaxcontratosService, MultaxcontratosService>();
            services.AddScoped<IMultaService, MultaService>();
            services.AddScoped<IFpContratosService,FpContratosService>();
            services.AddScoped<IFormaPagosService, FormaPagosService>();
            services.AddScoped<IPrestamosService,PrestamosService>();
            services.AddScoped<IPrestamosxpersonasService,PrestamosxpersonasService>();
            services.AddScoped<IPersonasService, PersonasService>();
            services.AddScoped<ICelebracionsService,CelebracionsService>();
            services.AddScoped<IEventosService,EventosService>();
            services.AddScoped<IGanadorsService, GanadorsService>();
            services.AddScoped<IPremiosService, PremiosService>();
            services.AddScoped<IBeneficiosService, BeneficiosService>();
            services.AddScoped<ISuscripcionsService, SuscripcionsService>();
            services.AddScoped<IDesignacionsService,DesignacionsService>();
            services.AddScoped<ITurnosService, TurnosService>();
            services.AddScoped<IImpxinstalacionsService, ImpxinstalacionsService>();
            services.AddScoped<IImpuestosService, ImpuestosService>();
            services.AddScoped<IGastoxinstsService,GastoxinstsService >();
            services.AddScoped<IGastosService, GastosService>();
            services.AddScoped<IProductoAsignadosService, ProductoAsignadosService>();
            services.AddScoped<IProductosService, ProductosService>();
            services.AddScoped<IPedidoProductosService, PedidoProductosService>();
            services.AddScoped<IOrdenComprasService, OrdenComprasService>();
            services.AddScoped<IComprasService, ComprasService>();
            services.AddScoped<IDetalleComprasService, DetalleComprasService>();
            services.AddScoped<IFacturasService, FacturasService>();
            services.AddScoped<IDetalleFacturasService, DetalleFacturasService>();
            services.AddScoped<IMantenimientosService, MantenimientosService>();
            services.AddScoped<IDetalleMantenimientosService, DetalleMantenimientosService>();
            services.AddScoped<IServiciosService, ServiciosService>();
            services.AddScoped<IProveedorsService, ProveedorsService>();
            services.AddScoped<IOrdenPagosService, OrdenPagosService>();
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
                options.AddPolicy("ClientRole", policy => policy.RequireClaim("DracoSutossRoles", "client"));
            });
        }

        public static void ConfigureAuth0Authetication(this IServiceCollection services)
        {
            services.AddAuthorization(
                options =>
            {
                options.AddPolicy("ClientRole", policy => policy.RequireClaim("DracoSutossRoles", "client"));
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
