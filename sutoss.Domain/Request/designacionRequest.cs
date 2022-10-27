using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Request
{
    public class designacionRequest
    {
        public int IdDesignacion { get; set; }
public string DNombre { get; set; }
public DateOnly DInicio { get; set; }
public DateOnly DFin { get; set; }
public int InstalacionIdInstalacion { get; set; }
public int PersonaIdPersona { get; set; }
public int TurnoIdTurno { get; set; }

    }
}
