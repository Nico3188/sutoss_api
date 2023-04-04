using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class FamiliarRequest
    {
        public int IdFamiliar { get; set; }
    public string FamDni { get; set; }
    public string FamNombre { get; set; }
    public string FamDomicilio { get; set; }
    public DateTime Famnacimiento { get; set; }
    public int PersonaIdPersona { get; set; }
    public string FamVinculo {get; set; }
    }
}
