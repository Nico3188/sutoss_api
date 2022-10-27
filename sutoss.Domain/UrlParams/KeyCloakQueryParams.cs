using sutoss.Domain.Services.Domain.Attributes;
using JobSeekerRecruitingApp.Data.Models.QueryParams.Base;

namespace sutoss.Domain.Services.Domain.UrlParams
{
    public class KeyCloakQueryParams : BaseQueryParams
    {
        [UrlAttribute("client_id")]
        public string ClientId { get; set; }
        [UrlAttribute("grant_type")] 
        public string GrantType { get; set; }
        [UrlAttribute("client_secret")]
        public string ClientSecret { get; set; }
        [UrlAttribute("scope")]
        public string Scope { get; set; }
        [UrlAttribute("username")]
        public string Username { get; set; }
        [UrlAttribute("password")]
        public string Password { get; set; }
    }
}
