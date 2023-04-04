using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class CuotaPrestamo
    {
        public int IdCuotaPrestamo { get; set; }
        public float CpImporte { get; set; }
        public DateTime CpFpago { get; set; }
        public int CpNumcuota { get; set; }
        public int CpCantcuotas { get; set; }
        public string CpEstado { get; set; }
        public int IdPrestamosxpersona { get; set; }
    }
}
