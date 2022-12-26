using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Turno
    {
        public Turno()
        {
            Designacions = new HashSet<Designacion>();
        }

        public int IdTurno { get; set; }
        public string TNombre { get; set; }
        public string THoraInicio { get; set; }
        public string THoraFin { get; set; }
        public string Observacion { get; set; }

        public virtual ICollection<Designacion> Designacions { get; set; }
    }
}
