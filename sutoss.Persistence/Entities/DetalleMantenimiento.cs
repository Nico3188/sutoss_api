using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class DetalleMantenimiento
    {
        public int IdDetalleMantenimiento { get; set; }
        public float DetmanCantidad { get; set; }
        public int MantenimientoIdMantenimiento { get; set; }
        public int ServicioIdServicio { get; set; }
        public int ProductoIdProducto { get; set; }

        public virtual Mantenimiento MantenimientoIdMantenimientoNavigation { get; set; }
        public virtual Producto ProductoIdProductoNavigation { get; set; }
        public virtual Servicio ServicioIdServicioNavigation { get; set; }
    }
}
