using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class PedidoProductoRequest
    {
        public int IdPedidoProducto { get; set; }
public string PpCodigo { get; set; }
public string PpAprueba { get; set; }
public string PpAutorizado { get; set; }
public string PpPedidopor { get; set; }
public int MantenimientoIdMantenimiento { get; set; }

    }
}
