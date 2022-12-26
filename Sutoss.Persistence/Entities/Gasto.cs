using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Gasto
    {
        public Gasto()
        {
            Gastoxinsts = new HashSet<Gastoxinst>();
        }

        public int IdGasto { get; set; }
        public string GNombre { get; set; }
        public string GObservacion { get; set; }
        public string GFreciencia { get; set; }
        public string GTipo { get; set; }

        public virtual ICollection<Gastoxinst> Gastoxinsts { get; set; }
    }
}
