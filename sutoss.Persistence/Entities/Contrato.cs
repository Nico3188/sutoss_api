using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Contrato
    {
        public Contrato()
        {
            Checkxcontratos = new HashSet<Checkxcontrato>();
            FpContratos = new HashSet<FpContrato>();
            Multaxcontratos = new HashSet<Multaxcontrato>();
        }

        public int IdContrato { get; set; }
        public string CNombre { get; set; }
        public string CDescripcion { get; set; }
        public string CTexto { get; set; }
        public int AlquilerIdAlquiler { get; set; }
        public int PersonaIdPersona { get; set; }

        public virtual Alquiler AlquilerIdAlquilerNavigation { get; set; }
        public virtual Persona PersonaIdPersonaNavigation { get; set; }
        public virtual ICollection<Checkxcontrato> Checkxcontratos { get; set; }
        public virtual ICollection<FpContrato> FpContratos { get; set; }
        public virtual ICollection<Multaxcontrato> Multaxcontratos { get; set; }
    }
}
