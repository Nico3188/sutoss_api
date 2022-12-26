using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class PrestamosxpersonaResponse
    {
        public int IdPrestamosxpersona { get; set; }
public DateOnly PpFecha { get; set; }
public int PpCantCuotas { get; set; }
public string PpObrsevacion { get; set; }
public string PpEstado { get; set; }
public int PrestamoIdPrestamo { get; set; }
public int PersonaIdPersona { get; set; }

    }
}
