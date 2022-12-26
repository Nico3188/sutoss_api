using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class CuotaAnticipoRequest
    {
        public int IdCuotaAnticipo { get; set; }
public int CaNcuota { get; set; }
public int CaCantcuotas { get; set; }
public DateOnly CaFpago { get; set; }
public string CaEstado { get; set; }
public int AnticipoIdAnticipo { get; set; }
public int PersonaIdPersona { get; set; }

    }
}
