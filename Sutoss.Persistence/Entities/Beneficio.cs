using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Beneficio
    {
        public Beneficio()
        {
            Suscripcions = new HashSet<Suscripcion>();
        }

        public int IdBeneficio { get; set; }
        public string BNombre { get; set; }
        public string BDescripcion { get; set; }

        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
