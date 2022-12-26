using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class CuotaPrestamoResponse
    {
        public int IdCuotaPrestamo { get; set; }
public float CpImporte { get; set; }
public DateOnly CpFpago { get; set; }
public int CpNumcuota { get; set; }
public int CpCantcuotas { get; set; }
public string CpEstado { get; set; }
public int IdPrestamosxpersona { get; set; }

    }
}
