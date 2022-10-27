using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class OrdenPago
    {
        public int IdRdenPago { get; set; }
        public string OpCodigo { get; set; }
        public int? OpNumero { get; set; }
        public DateOnly OpFecha { get; set; }
        public string OpMonto { get; set; }
        public int ProveedorIdProveedor { get; set; }

        public virtual Proveedor ProveedorIdProveedorNavigation { get; set; }
    }
}
