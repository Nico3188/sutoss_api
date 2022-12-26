using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class OrdenPagoRequest
    {
        public int IdRdenPago { get; set; }
public string OpCodigo { get; set; }
public DateOnly OpFecha { get; set; }
public string OpMonto { get; set; }
public int ProveedorIdProveedor { get; set; }

    }
}
