using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using sutoss.Extensions;
using Quartz;
//using sutoss.Drivers.Schedulers;

// dotnet tool install --global dotnet-ef
// dotnet ef dbcontext scaffold "server=localhost;port=3306;database=sutoss;uid=root;password=SoloyoNS311088" Pomelo.EntityFrameworkCore.MySql --project . --startup-project . --output-dir "Z:\Personal_Projects\sutoss\sutoss.Persistence\Entities" --context sutossContext -f -v
// dotnet ef dbcontext scaffold "server=localhost;port=3306;database=sutoss;uid=root;password=SoloyoNS311088" Pomelo.EntityFrameworkCore.MySql --project . --startup-project . --output-dir "D:\ByteTec\Sutoss\sutoss\sutoss.Persistence\Entities" --context sutossContext -f -v


namespace sutoss
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
            services.AddDbContext<sutossContext>(options => options.UseMySql(
                _connectionString,
                ServerVersion.AutoDetect(_connectionString)));

            services.ConfigureSystem(Configuration);
            services.ConfigureCors();
            services.ConfigureRepos();
            services.ConfigureInnerServices();
            services.ConfigureValidators();
            services.ConfigureScheduler(Configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.ConfigureAuth0Authetication(Configuration);
            services.ConfigureAuth0Authorization();
            services.AddControllers();
            services.AddHttpClient();
            ConfigureSwagger(services);
        }

        public void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "sutoss", Version = "1" });
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
