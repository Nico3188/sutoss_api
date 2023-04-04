using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class ProductoAsignado
    {
        public int IdProductoAsignado { get; set; }
        public DateTime PaFecha { get; set; }
        public string PaEstadoProducto { get; set; }
        public int InstalacionIdInstalacion { get; set; }
        public int ProductoIdProducto { get; set; }

        public virtual Instalacion InstalacionIdInstalacionNavigation { get; set; }
        public virtual Producto ProductoIdProductoNavigation { get; set; }
    }
}
