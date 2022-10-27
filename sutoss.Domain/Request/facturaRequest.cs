using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Request
{
    public class facturaRequest
    {
        public int IdFactura { get; set; }
public string FCodigo { get; set; }
public float FMonto { get; set; }
public string FMoneda { get; set; }
public int CompraIdCompra { get; set; }
public int ImpuestoIdImpuseto { get; set; }

    }
}
