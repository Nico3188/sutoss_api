using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class CheckxcontratoResponse
    {
        public int IdCheckxContrato { get; set; }
public DateOnly ChcFecha { get; set; }
public string ChcResponsables { get; set; }
public string ChcObservaciones { get; set; }
public string ChcNumero { get; set; }
public int CheklistIdChecklist { get; set; }
public int ContratoIdContrato { get; set; }

    }
}
