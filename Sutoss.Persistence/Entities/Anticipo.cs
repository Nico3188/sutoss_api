using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Anticipo
    {
        public int IdAnticipo { get; set; }
        public string AConcepto { get; set; }
        public string AMonto { get; set; }
        public DateOnly AFecha { get; set; }
        public string AAprobado { get; set; }
        public string AEstado { get; set; }
    }
}
