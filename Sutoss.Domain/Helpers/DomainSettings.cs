using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Helpers
{
    public class DomainSettings
    {
        public AppSettings AppSettings { get; set; }
        public AD Ad { get; set; }
        public JWT JWT { get; set; }
        public string PublicUrl { get; set; }
        public Apis Apis { get; set; }
        public Mail Mail { get; set; }
        public MailScheduler MailScheduler { get; set; }
        public FilesStoragePath FilesStoragePath { get; set; }
    }

    public class AppSettings
    {
        public string Secret { get; set; }
    }

    public class AD
    {
        public string Url { get; set; }
    }

    public class JWT
    {
        public string Issuer { get; set; }
        public string Authority { get; set; }
        public string Audience { get; set; }
        public string ClientId { get; set; }
        public string GrantType { get; set; }
        public string ClientSecret { get; set; }
        public string Scope { get; set; }
        public string AuthTokenUrl { get; set; }
    }

    public class Apis
    {
        public string Holidays { get; set; }
        public string JobSeekerWorkPlaces { get; set; }
    }
    public class Mail
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class MailScheduler
    {
        public string JobKey { get; set; }
        public string Identity { get; set; }
        public string CronSchedule { get; set; }
    }

    public class FilesStoragePath
    {
        public string Path { get; set; }
    }
}
