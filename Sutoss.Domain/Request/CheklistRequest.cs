using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class CheklistRequest
    {
        public int IdChecklist { get; set; }
public string ChCodigo { get; set; }
public string ChNombre { get; set; }
public string ChDescripcion { get; set; }
public string ChDocumento { get; set; }

    }
}
