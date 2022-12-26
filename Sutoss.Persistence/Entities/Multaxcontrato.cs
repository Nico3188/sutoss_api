using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Multaxcontrato
    {
        public int IdMultaxContrato { get; set; }
        public DateOnly MxcFecha { get; set; }
        public string MxcEstado { get; set; }
        public int MultaIdMulta { get; set; }
        public int ContratoIdContrato { get; set; }
        public string MxcObservacionl { get; set; }

        public virtual Contrato ContratoIdContratoNavigation { get; set; }
        public virtual Multum MultaIdMultaNavigation { get; set; }
    }
}
