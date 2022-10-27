using sutoss.KeyCloak.Models;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;

namespace sutoss.KeyCloak
{
    public static class KeyCloakManager
    {
        public static string GetExternalUserId(ClaimsPrincipal user)
        {
            return user.Claims.First(c => c.Type.Equals("preferred_username")).Value.ToUpper();
        }

        public static ResourceAccess GetRoles(ClaimsPrincipal user)
        {
            var jsonObject = user.Claims.First(c => c.Type.Equals("resource_access")).Value;
            return JsonConvert.DeserializeObject<ResourceAccess>(jsonObject);
        }
    }
}
