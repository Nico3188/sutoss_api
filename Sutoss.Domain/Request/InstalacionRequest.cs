using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class InstalacionRequest
    {
        public int IdInstalacion { get; set; }
public string INombre { get; set; }
public string IMetroscuadrados { get; set; }
public string IDescripcion { get; set; }
public int LocalidadIdLocalidad { get; set; }

    }
}
