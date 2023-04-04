using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class FpContrato
    {
        public int IdFpContrato { get; set; }
        public float FpcMonto { get; set; }
        public string FpcTipo { get; set; }
        public DateTime FpcFcancelacion { get; set; }
        public int FpcSena { get; set; }
        public string FpcSenatipo { get; set; }
        public int FormaPagoIdFormaPago { get; set; }
        public int ContratoIdContrato { get; set; }
        public DateTime FpcFpagosena { get; set; }
        public string FpcUrlimg { get; set; }

        public virtual Contrato ContratoIdContratoNavigation { get; set; }
        public virtual FormaPago FormaPagoIdFormaPagoNavigation { get; set; }
    }
}
