using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Departamento
    {
        public Departamento()
        {
            Localidads = new HashSet<Localidad>();
        }

        public int IdDepartamento { get; set; }
        public string DNombre { get; set; }
        public int ProvinciaIdProvincia { get; set; }

        public virtual Provincium ProvinciaIdProvinciaNavigation { get; set; }
        public virtual ICollection<Localidad> Localidads { get; set; }
    }
}
