using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class HorarioRequest
    {
        public int IdHorario { get; set; }
public string HNombre { get; set; }
public string HHoraInicio { get; set; }
public string HHoraFin { get; set; }

    }
}
