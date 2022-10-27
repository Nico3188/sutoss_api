using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Anticipo
    {
        public Anticipo()
        {
            CuotaAnticipos = new HashSet<CuotaAnticipo>();
        }

        public int IdAnticipo { get; set; }
        public string AConcepto { get; set; }
        public string AMonto { get; set; }
        public DateOnly AFecha { get; set; }
        public string AAprobado { get; set; }
        public string AEstado { get; set; }

        public virtual ICollection<CuotaAnticipo> CuotaAnticipos { get; set; }
    }
}
