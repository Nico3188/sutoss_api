using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class ProductoAsignadoRequest
    {
        public int IdProductoAsignado { get; set; }
public DateOnly PaFecha { get; set; }
public string PaEstadoProducto { get; set; }
public int InstalacionIdInstalacion { get; set; }
public int ProductoIdProducto { get; set; }

    }
}
