using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class CuotaAnticipo
    {
        public int IdCuotaAnticipo { get; set; }
        public int CaNcuota { get; set; }
        public int CaCantcuotas { get; set; }
        public DateOnly CaFpago { get; set; }
        public string CaEstado { get; set; }
        public int AnticipoIdAnticipo { get; set; }
        public int PersonaIdPersona { get; set; }

        public virtual Anticipo AnticipoIdAnticipoNavigation { get; set; }
        public virtual Persona PersonaIdPersonaNavigation { get; set; }
    }
}
