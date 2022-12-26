using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class MultaxcontratoResponse
    {
        public int IdMultaxContrato { get; set; }
public DateOnly MxcFecha { get; set; }
public string MxcEstado { get; set; }
public int MultaIdMulta { get; set; }
public int ContratoIdContrato { get; set; }
public string MxcObservacionl { get; set; }

    }
}
