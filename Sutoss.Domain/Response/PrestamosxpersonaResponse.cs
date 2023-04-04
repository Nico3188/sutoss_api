using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class PrestamosxpersonaResponse
    {
        public int IdPrestamosxpersona { get; set; }
        public DateOnly PpFecha { get; set; }
        public int PpCantCuotas { get; set; }
        public string PpObrsevacion { get; set; }
        public string PpEstado { get; set; }
        //public int PrestamoIdPrestamo { get; set; }
        //Agregado por Nico
        public string PreMonto { get; set; }
        public string PreInteres { get; set; }
        public string PreEstado { get; set; }
        //Fin de Agregado por Nico
        public int PersonaIdPersona { get; set; }
        public string PerNombre {get; set;}
        public int? PerNafiliadio { get; set;}

    }
}
