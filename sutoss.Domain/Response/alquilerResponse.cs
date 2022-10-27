using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Response
{
    public class alquilerResponse
    {
        public int IdAlquiler { get; set; }
public DateOnly AFinicio { get; set; }
public DateOnly AFfin { get; set; }
public int ACantaduldos { get; set; }
public int ACantmenores { get; set; }
public int AMascotas { get; set; }
public int PersonaIdPersona { get; set; }
public int InstalacionIdInstalacion { get; set; }

    }
}
