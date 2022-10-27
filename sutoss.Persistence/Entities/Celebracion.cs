using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Celebracion
    {
        public Celebracion()
        {
            Ganadors = new HashSet<Ganador>();
        }

        public int IdCelebracion { get; set; }
        public string CConfirmado { get; set; }
        public string CAsistencio { get; set; }
        public int EventoIdEvento { get; set; }
        public int PersonaIdPersona { get; set; }

        public virtual Evento EventoIdEventoNavigation { get; set; }
        public virtual Persona PersonaIdPersonaNavigation { get; set; }
        public virtual ICollection<Ganador> Ganadors { get; set; }
    }
}
