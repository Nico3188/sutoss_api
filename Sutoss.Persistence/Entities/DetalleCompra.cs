using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public float DetCantidad { get; set; }
        public float DetPrecionitario { get; set; }
        public string DetalleCompracol { get; set; }
        public int CompraIdCompra { get; set; }
        public int ProductoIdProducto { get; set; }

        public virtual Compra CompraIdCompraNavigation { get; set; }
        public virtual Producto ProductoIdProductoNavigation { get; set; }
    }
}
