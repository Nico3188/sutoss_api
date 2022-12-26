using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Mantenimiento
    {
        public Mantenimiento()
        {
            DetalleMantenimientos = new HashSet<DetalleMantenimiento>();
            PedidoProductos = new HashSet<PedidoProducto>();
        }

        public int IdMantenimiento { get; set; }
        public DateOnly MFecha { get; set; }
        public string MEstado { get; set; }
        public string MCosto { get; set; }
        public string MAcargo { get; set; }
        public int InstalacionIdInstalacion { get; set; }

        public virtual Instalacion InstalacionIdInstalacionNavigation { get; set; }
        public virtual ICollection<DetalleMantenimiento> DetalleMantenimientos { get; set; }
        public virtual ICollection<PedidoProducto> PedidoProductos { get; set; }
    }
}
