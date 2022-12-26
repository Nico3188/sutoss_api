using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class OrdenCompraResponse
    {
        public int IdOrdenCompra { get; set; }
public string OcCodigo { get; set; }
public string OcEstado { get; set; }
public DateOnly OcFecha { get; set; }
public string OcCargadopor { get; set; }
public int PedidoProductoIdPedidoProducto { get; set; }

    }
}
