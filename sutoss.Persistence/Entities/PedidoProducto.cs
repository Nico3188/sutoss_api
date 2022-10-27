using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class PedidoProducto
    {
        public PedidoProducto()
        {
            OrdenCompras = new HashSet<OrdenCompra>();
        }

        public int IdPedidoProducto { get; set; }
        public string PpCodigo { get; set; }
        public int? PpNumero { get; set; }
        public string PpAprueba { get; set; }
        public string PpAutorizado { get; set; }
        public string PpPedidopor { get; set; }
        public int MantenimientoIdMantenimiento { get; set; }

        public virtual Mantenimiento MantenimientoIdMantenimientoNavigation { get; set; }
        public virtual ICollection<OrdenCompra> OrdenCompras { get; set; }
    }
}
