using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Designacion
    {
        public int IdDesignacion { get; set; }
        public string DNombre { get; set; }
        public DateTime DInicio { get; set; }
        public DateTime DFin { get; set; }
        public int InstalacionIdInstalacion { get; set; }
        public int PersonaIdPersona { get; set; }
        public int TurnoIdTurno { get; set; }

        public virtual Instalacion InstalacionIdInstalacionNavigation { get; set; }
        public virtual Persona PersonaIdPersonaNavigation { get; set; }
        public virtual Turno TurnoIdTurnoNavigation { get; set; }
    }
}
