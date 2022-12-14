using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Suscripcion
    {
        public int IdSuscripcion { get; set; }
        public DateOnly SFecha { get; set; }
        public int SCantidad { get; set; }
        public int BeneficioIdBeneficio { get; set; }
        public int PersonaIdPersona { get; set; }

        public virtual Beneficio BeneficioIdBeneficioNavigation { get; set; }
        public virtual Persona PersonaIdPersonaNavigation { get; set; }
    }
}
