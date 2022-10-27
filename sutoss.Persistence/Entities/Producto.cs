using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Producto
    {
        public Producto()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
            DetalleMantenimientos = new HashSet<DetalleMantenimiento>();
            ProductoAsignados = new HashSet<ProductoAsignado>();
        }

        public int IdProducto { get; set; }
        public int PCodigo { get; set; }
        public string PNombre { get; set; }
        public string PDescripcion { get; set; }
        public int PCantidad { get; set; }
        public string PUnidad { get; set; }
        public int? PCodBarra { get; set; }
        public string PEstado { get; set; }
        public DateOnly? PFCompra { get; set; }

        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleMantenimiento> DetalleMantenimientos { get; set; }
        public virtual ICollection<ProductoAsignado> ProductoAsignados { get; set; }
    }
}
