using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class DetalleCompraResponse
    {
        public int IdDetalleCompra { get; set; }
public float DetCantidad { get; set; }
public float DetPrecionitario { get; set; }
public string DetalleCompracol { get; set; }
public int CompraIdCompra { get; set; }
public int ProductoIdProducto { get; set; }

    }
}
