using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Compra
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
            Facturas = new HashSet<Factura>();
        }

        public int IdCompra { get; set; }
        public string CompCodigo { get; set; }
        public int? CompNumero { get; set; }
        public DateTime CompFecha { get; set; }
        public string CompEstado { get; set; }
        public string CompPreciofinal { get; set; }
        public int OrdenCompraIdOrdenCompra { get; set; }

        public virtual OrdenCompra OrdenCompraIdOrdenCompraNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
