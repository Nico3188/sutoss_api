using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Impxinstalacion
    {
        public int IdIMpxinstalacion { get; set; }
        public DateOnly ImpxintVto { get; set; }
        public string ImpxintMonto { get; set; }
        public string ImpxintEstado { get; set; }
        public int ImpuestoIdImpuseto { get; set; }
        public int InstalacionIdInstalacion { get; set; }

        public virtual Impuesto ImpuestoIdImpusetoNavigation { get; set; }
        public virtual Instalacion InstalacionIdInstalacionNavigation { get; set; }
    }
}
