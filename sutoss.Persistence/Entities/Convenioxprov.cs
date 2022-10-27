using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Convenioxprov
    {
        public int IdConvenioxProv { get; set; }
        public int IdConvenio { get; set; }
        public int IdPersona { get; set; }
        public DateOnly? ConxpFinicio { get; set; }
        public DateOnly? ConxpFfin { get; set; }
        public string ConxpEstado { get; set; }
    }
}
