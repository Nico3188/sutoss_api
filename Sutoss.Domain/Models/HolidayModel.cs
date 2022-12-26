using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Models
{
    public class HolidayModel
    {
        [JsonProperty("dia")]
        public int Day { get; set; }
        [JsonProperty("mes")]
        public int Month { get; set; }
    }
}
