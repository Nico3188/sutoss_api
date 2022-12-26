using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class FpContratoRequest
    {
        public int IdFpContrato { get; set; }
public float FpcMonto { get; set; }
public int FpcNcouta { get; set; }
public int FpcCantidadCuota { get; set; }
public DateOnly PfFinicio { get; set; }
public DateOnly FpcFfin { get; set; }
public int FormaPagoIdFormaPago { get; set; }
public int ContratoIdContrato { get; set; }

    }
}
