using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Request
{
    public class mantenimientoRequest
    {
        public int IdMantenimiento { get; set; }
public DateOnly MFecha { get; set; }
public string MEstado { get; set; }
public string MCosto { get; set; }
public string MAcargo { get; set; }
public int InstalacionIdInstalacion { get; set; }

    }
}
