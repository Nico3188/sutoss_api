using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Gastoxinst
    {
        public int IdGastoxInst { get; set; }
        public string GasxintMonto { get; set; }
        public DateOnly GasxintVencimiento { get; set; }
        public string GasxintEstado { get; set; }
        public int GastoIdGasto { get; set; }
        public int InstalacionIdInstalacion { get; set; }

        public virtual Gasto GastoIdGastoNavigation { get; set; }
        public virtual Instalacion InstalacionIdInstalacionNavigation { get; set; }
    }
}
