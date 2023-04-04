using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Evento
    {
        public Evento()
        {
            Celebracions = new HashSet<Celebracion>();
        }

        public int IdEvento { get; set; }
        public string ENombre { get; set; }
        public DateTime EFecha { get; set; }
        public string EPrecio { get; set; }
        public int? ECarton { get; set; }
        public int? ECodigo { get; set; }
        public string EUbicacion { get; set; }

        public virtual ICollection<Celebracion> Celebracions { get; set; }
    }
}
