using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Premio
    {
        public Premio()
        {
            Ganadors = new HashSet<Ganador>();
        }

        public int IdPremios { get; set; }
        public string PNombre { get; set; }
        public string PDescriopcion { get; set; }

        public virtual ICollection<Ganador> Ganadors { get; set; }
    }
}
