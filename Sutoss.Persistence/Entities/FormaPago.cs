using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class FormaPago
    {
        public FormaPago()
        {
            FpContratos = new HashSet<FpContrato>();
        }

        public int IdFormaPago { get; set; }
        public string FpNombre { get; set; }
        public string FpSigno { get; set; }

        public virtual ICollection<FpContrato> FpContratos { get; set; }
    }
}
