using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class EventoResponse
    {
        public int IdEvento { get; set; }
public string ENombre { get; set; }
public DateOnly EFecha { get; set; }
public string EPrecio { get; set; }
public string EUbicacion { get; set; }

    }
}
