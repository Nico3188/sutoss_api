using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class LogOperacioneRequest
    {
        public int IdLogOperaciones { get; set; }
public string Operacion { get; set; }
public string Usuario { get; set; }

    }
}
