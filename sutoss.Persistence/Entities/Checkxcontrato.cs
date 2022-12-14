using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Checkxcontrato
    {
        public int IdCheckxContrato { get; set; }
        public DateOnly ChcFecha { get; set; }
        public string ChcResponsables { get; set; }
        public string ChcObservaciones { get; set; }
        public string ChcNumero { get; set; }
        public int CheklistIdChecklist { get; set; }
        public int ContratoIdContrato { get; set; }

        public virtual Cheklist CheklistIdChecklistNavigation { get; set; }
        public virtual Contrato ContratoIdContratoNavigation { get; set; }
    }
}
