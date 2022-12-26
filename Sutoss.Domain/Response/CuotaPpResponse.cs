using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class CuotaPpResponse
    {
        public int IdCuotaPp { get; set; }
public DateOnly CppFecha { get; set; }
public string CppCuota { get; set; }
public string CppEstado { get; set; }

    }
}
