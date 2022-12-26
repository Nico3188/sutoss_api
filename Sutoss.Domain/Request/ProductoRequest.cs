using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class ProductoRequest
    {
        public int IdProducto { get; set; }
public int PCodigo { get; set; }
public string PNombre { get; set; }
public string PDescripcion { get; set; }
public int PCantidad { get; set; }
public string PUnidad { get; set; }
public string PEstado { get; set; }

    }
}
