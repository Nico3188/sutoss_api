using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Request
{
    public class suscripcionRequest
    {
        public int IdSuscripcion { get; set; }
public DateOnly SFecha { get; set; }
public int SCantidad { get; set; }
public int BeneficioIdBeneficio { get; set; }
public int PersonaIdPersona { get; set; }

    }
}
