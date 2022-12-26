using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class SuscripcionRequest
    {
        public int IdSuscripcion { get; set; }
public DateOnly SFecha { get; set; }
public int SCantidad { get; set; }
public int BeneficioIdBeneficio { get; set; }
public int PersonaIdPersona { get; set; }

    }
}
