using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Familiar
    {
        public int IdFamiliar { get; set; }
        public string FamDni { get; set; }
        public string FamNombre { get; set; }
        public string FamDomicilio { get; set; }
        public DateTime? Famnacimiento { get; set; }
        public int PersonaIdPersona { get; set; }
        public string FamVinculo { get; set; }

        public virtual Persona PersonaIdPersonaNavigation { get; set; }
    }
}
