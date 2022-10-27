using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace sutoss.Extensions
{
    public static class SchedulerExtensions
    {
        public static void ConfigureScheduler(this IServiceCollection services, IConfiguration config)
        {
            //services.AddScoped<IAssingScheduledRoleTask, AssingScheduledRoleTask>();
            //services.AddScoped<IRemovingScheduledRoleTask, RemovingScheduledRoleTask>();

            ////https://andrewlock.net/using-quartz-net-with-asp-net-core-and-worker-services/
            //services.AddQuartz(q =>
            //{
            //    q.UseMicrosoftDependencyInjectionJobFactory();
            //    var jobKey = new JobKey(config["Jobs:RemovingScheduledRoleJobKey"]);
            //    q.AddJob<IRemovingScheduledRoleTask>(opts => opts.WithIdentity(jobKey));
            //    q.AddTrigger(opts => opts
            //        .ForJob(jobKey)
            //        .WithIdentity(config["Jobs:RemovingScheduledRoleIdentity"])
            //        .WithCronSchedule(config["Jobs:RemovingScheduledRoleCronSchedule"]));

            //    jobKey = new JobKey(config["Jobs:AssingScheduledRoleJobKey"]);
            //    q.AddJob<IAssingScheduledRoleTask>(opts => opts.WithIdentity(jobKey));
            //    q.AddTrigger(opts => opts
            //        .ForJob(jobKey)
            //        .WithIdentity(config["Jobs:AssingScheduledRoleIdentity"])
            //        .WithCronSchedule(config["Jobs:AssingScheduledRoleCronSchedule"]));
            //});

            //services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }

    }
}
