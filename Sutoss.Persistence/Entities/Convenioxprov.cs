using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Convenioxprov
    {
        public int IdConvenioxProv { get; set; }
        public int IdConvenio { get; set; }
        public int IdPersona { get; set; }
        public DateTime? ConxpFinicio { get; set; }
        public DateTime? ConxpFfin { get; set; }
        public string ConxpEstado { get; set; }
    }
}
