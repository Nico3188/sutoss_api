using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class DetalleFactura
    {
        public int IddetalleFactura { get; set; }
        public int DetfacCantidad { get; set; }
        public int FacturaIdFactura { get; set; }

        public virtual Factura FacturaIdFacturaNavigation { get; set; }
    }
}
