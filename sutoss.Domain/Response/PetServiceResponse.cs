using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Response
{
    public class PetServiceResponse
    {
        public int PetServiceId { get; set; }
public int PetId { get; set; }
public int ServiceId { get; set; }
public DateTime Stamp { get; set; }
public int ExpirationDay { get; set; }

    }
}
