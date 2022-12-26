using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class DetalleMantenimientoRequest
    {
        public int IdDetalleMantenimiento { get; set; }
public float DetmanCantidad { get; set; }
public int MantenimientoIdMantenimiento { get; set; }
public int ServicioIdServicio { get; set; }
public int ProductoIdProducto { get; set; }

    }
}
