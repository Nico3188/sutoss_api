using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Multum
    {
        public Multum()
        {
            Multaxcontratos = new HashSet<Multaxcontrato>();
        }

        public int IdMulta { get; set; }
        public string MNombre { get; set; }
        public string MDescripcion { get; set; }
        public string MMonto { get; set; }

        public virtual ICollection<Multaxcontrato> Multaxcontratos { get; set; }
    }
}
