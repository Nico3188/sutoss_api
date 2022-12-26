using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Localidad
    {
        public Localidad()
        {
            Instalacions = new HashSet<Instalacion>();
        }

        public int IdLocalidad { get; set; }
        public string LNombre { get; set; }
        public int DepartamentoIdDepartamento { get; set; }

        public virtual Departamento DepartamentoIdDepartamentoNavigation { get; set; }
        public virtual ICollection<Instalacion> Instalacions { get; set; }
    }
}
