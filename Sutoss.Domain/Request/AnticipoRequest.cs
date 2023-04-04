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
        public DateTime AFecha { get; set; }
        public string AAprobado { get; set; }
        public string AEstado { get; set; }
        public int PersonaIdPersona { get; set; }
        public int PerNafiliadio { get; set; }
        public string PerNombre{ get; set; }


//        public int IdAnticipo { get; set; }
// public string AConcepto { get; set; }
// public string AMonto { get; set; }
// public DateOnly AFecha { get; set; }

// public string AAprobado { get; set; }
// public string AEstado { get; set; }
    }
}
