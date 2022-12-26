using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Impuesto
    {
        public Impuesto()
        {
            Facturas = new HashSet<Factura>();
            Impxinstalacions = new HashSet<Impxinstalacion>();
        }

        public int IdImpuseto { get; set; }
        public string INombre { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<Impxinstalacion> Impxinstalacions { get; set; }
    }
}
