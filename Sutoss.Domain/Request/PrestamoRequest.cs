using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class PrestamoRequest
    {
        public int IdPrestamo { get; set; }
        public string PreNombre { get; set; }
        public string PreMonto { get; set; }
        public string PreInteres { get; set; }
        public string PreEstado { get; set; }

    }
}
