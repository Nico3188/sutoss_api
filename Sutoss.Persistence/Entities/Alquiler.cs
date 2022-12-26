using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Alquiler
    {
        public Alquiler()
        {
            Contratos = new HashSet<Contrato>();
        }

        public int IdAlquiler { get; set; }
        public DateOnly AFinicio { get; set; }
        public DateOnly AFfin { get; set; }
        public int ACantaduldos { get; set; }
        public int ACantmenores { get; set; }
        public int AMascotas { get; set; }
        public int PersonaIdPersona { get; set; }
        public int InstalacionIdInstalacion { get; set; }

        public virtual Instalacion InstalacionIdInstalacionNavigation { get; set; }
        public virtual Persona PersonaIdPersonaNavigation { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
    }
}
