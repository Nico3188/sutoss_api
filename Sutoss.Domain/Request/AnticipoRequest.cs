using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class AnticipoRequest
    {
        public int IdAnticipo { get; set; }
public string AConcepto { get; set; }
public string AMonto { get; set; }
public DateOnly AFecha { get; set; }
public string AAprobado { get; set; }
public string AEstado { get; set; }

    }
}
