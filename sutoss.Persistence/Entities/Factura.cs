using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Factura
    {
        public Factura()
        {
            DetalleFacturas = new HashSet<DetalleFactura>();
        }

        public int IdFactura { get; set; }
        public string FCodigo { get; set; }
        public float FMonto { get; set; }
        public string FMoneda { get; set; }
        public int CompraIdCompra { get; set; }
        public int ImpuestoIdImpuseto { get; set; }

        public virtual Compra CompraIdCompraNavigation { get; set; }
        public virtual Impuesto ImpuestoIdImpusetoNavigation { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
