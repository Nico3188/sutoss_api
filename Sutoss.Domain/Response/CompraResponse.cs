using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class CompraResponse
    {
        public int IdCompra { get; set; }
public string CompCodigo { get; set; }
public DateOnly CompFecha { get; set; }
public string CompEstado { get; set; }
public string CompPreciofinal { get; set; }
public int OrdenCompraIdOrdenCompra { get; set; }

    }
}
