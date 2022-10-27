using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class FpContrato
    {
        public int IdFpContrato { get; set; }
        public float FpcMonto { get; set; }
        public int FpcNcouta { get; set; }
        public int FpcCantidadCuota { get; set; }
        public DateOnly PfFinicio { get; set; }
        public DateOnly FpcFfin { get; set; }
        public int FormaPagoIdFormaPago { get; set; }
        public int ContratoIdContrato { get; set; }

        public virtual Contrato ContratoIdContratoNavigation { get; set; }
        public virtual FormaPago FormaPagoIdFormaPagoNavigation { get; set; }
    }
}
