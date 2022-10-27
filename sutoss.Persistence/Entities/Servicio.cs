using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Servicio
    {
        public Servicio()
        {
            DetalleMantenimientos = new HashSet<DetalleMantenimiento>();
        }

        public int IdServicio { get; set; }
        public string SNombre { get; set; }
        public string SPasos { get; set; }
        public string SCosto { get; set; }
        public string SHoras { get; set; }
        public string SPersonalnecesario { get; set; }

        public virtual ICollection<DetalleMantenimiento> DetalleMantenimientos { get; set; }
    }
}
