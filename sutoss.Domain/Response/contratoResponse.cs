using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Response
{
    public class contratoResponse
    {
        public int IdContrato { get; set; }
public string CNombre { get; set; }
public string CDescripcion { get; set; }
public string CTexto { get; set; }
public int AlquilerIdAlquiler { get; set; }
public int PersonaIdPersona { get; set; }

    }
}
