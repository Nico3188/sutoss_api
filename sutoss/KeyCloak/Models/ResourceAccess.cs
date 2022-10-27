using Newtonsoft.Json;
using System.Collections.Generic;

namespace sutoss.KeyCloak.Models
{
    public class ResourceAccess
    {
        [JsonProperty("MPFSESA")]
        public MPFSESA Mpfsesa { get; set; }
    }

    public class MPFSESA
    {
        [JsonProperty("roles")]
        public List<string> Roles { get; set; }
    }
}
