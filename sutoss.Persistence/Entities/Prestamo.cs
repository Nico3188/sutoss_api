using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            Prestamosxpersonas = new HashSet<Prestamosxpersona>();
        }

        public int IdPrestamo { get; set; }
        public string PreNombre { get; set; }
        public string PreMonto { get; set; }
        public string PreInteres { get; set; }
        public string PreEstado { get; set; }

        public virtual ICollection<Prestamosxpersona> Prestamosxpersonas { get; set; }
    }
}
