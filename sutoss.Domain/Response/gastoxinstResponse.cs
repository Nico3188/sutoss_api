using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Response
{
    public class gastoxinstResponse
    {
        public int IdGastoxInst { get; set; }
public string GasxintMonto { get; set; }
public DateOnly GasxintVencimiento { get; set; }
public string GasxintEstado { get; set; }
public int GastoIdGasto { get; set; }
public int InstalacionIdInstalacion { get; set; }

    }
}
