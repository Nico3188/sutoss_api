using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Provincium
    {
        public Provincium()
        {
            Departamentos = new HashSet<Departamento>();
        }

        public int IdProvincia { get; set; }
        public string PNombre { get; set; }
        public string PCodigo { get; set; }

        public virtual ICollection<Departamento> Departamentos { get; set; }
    }
}
