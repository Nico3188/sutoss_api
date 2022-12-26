using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class ImpxinstalacionResponse
    {
        public int IdIMpxinstalacion { get; set; }
public DateOnly ImpxintVto { get; set; }
public string ImpxintMonto { get; set; }
public string ImpxintEstado { get; set; }
public int ImpuestoIdImpuseto { get; set; }
public int InstalacionIdInstalacion { get; set; }

    }
}
