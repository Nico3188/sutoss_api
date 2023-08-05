using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using Sutoss.Extensions;
using Quartz;
//using Sutoss.Drivers.Schedulers;

// dotnet tool install --global dotnet-ef
// dotnet ef dbcontext scaffold "server=localhost;port=3306;database=petcare;uid=root;password=1234" Pomelo.EntityFrameworkCore.MySql --project . --startup-project . --output-dir "Z:\Personal_Projects\Sutoss\Sutoss.Persistence\Entities" --context SutossContext -f -v

// dotnet ef dbcontext scaffold "server=localhost;port=3306;database=sutoss;uid=root;password=SoloyoNS311088" Pomelo.EntityFrameworkCore.MySql --project . --startup-project . --output-dir "F:\ByteTec\Sutoss\Sutoss\Sutoss.Persistence\Entities" --context SutossContext -f -v

// Wolfbuilder Sutoss SutossContext Users User


namespace Sutoss
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var _connectionString = Configuration.GetConnectionString("MySql");
            //Server=myServerAddress;Port=1234;Database=myDataBase;Uid=myUsername;Pwd=myPassword; 
            // var _connectionString = Server=127.0.0.1;Port=3306;Database=Sutoss;Uid=root;Pwd=SoloyoNS311088";//colocamos la conexion a la base de datos
            services.AddDbContext<SutossContext>(options => options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString)));

            services.ConfigureSystem(Configuration);
            services.ConfigureCors();
            services.ConfigureRepos();
            services.ConfigureInnerServices();
            // services.ConfigureValidators();
            services.ConfigureScheduler(Configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ConfigureAutheticationV2(Configuration);
            services.AddControllers();
            services.AddHttpClient();
            ConfigureSwagger(services);
        }

        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sutoss", Version = "1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseCors("AllowAll");
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // custom jwt auth middleware
            // app.UseMiddleware<JwtMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
