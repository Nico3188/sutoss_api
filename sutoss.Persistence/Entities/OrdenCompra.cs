using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class OrdenCompra
    {
        public OrdenCompra()
        {
            Compras = new HashSet<Compra>();
        }

        public int IdOrdenCompra { get; set; }
        public string OcCodigo { get; set; }
        public int? OcNumero { get; set; }
        public string OcEstado { get; set; }
        public DateOnly OcFecha { get; set; }
        public string OcCargadopor { get; set; }
        public int PedidoProductoIdPedidoProducto { get; set; }

        public virtual PedidoProducto PedidoProductoIdPedidoProductoNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
