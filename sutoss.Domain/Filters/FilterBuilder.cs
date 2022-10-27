using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace sutoss.Domain.Services.Domain.Filters
{
    public static class FilterBuilder
    {
        public static T BuildFilterFromBase64<T>(string base64)
        {
            byte[] data = Convert.FromBase64String(base64);
            string decodedString = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<T>(decodedString);
        }
        
    }
}
