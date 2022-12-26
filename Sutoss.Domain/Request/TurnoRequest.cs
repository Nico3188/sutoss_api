using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class TurnoRequest
    {
        public int IdTurno { get; set; }
public string TNombre { get; set; }
public string THoraInicio { get; set; }
public string THoraFin { get; set; }
public string Observacion { get; set; }

    }
}
