using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            OrdenPagos = new HashSet<OrdenPago>();
        }

        public int IdProveedor { get; set; }
        public string PNombre { get; set; }
        public int Cuit { get; set; }
        public string PRazonsocial { get; set; }
        public string PCondicionanteiva { get; set; }
        public int? PCelular { get; set; }
        public string PCorreo { get; set; }
        public string PDomicilio { get; set; }
        public string PNombrecontacto { get; set; }
        public string PCelcontacto { get; set; }

        public virtual ICollection<OrdenPago> OrdenPagos { get; set; }
    }
}
