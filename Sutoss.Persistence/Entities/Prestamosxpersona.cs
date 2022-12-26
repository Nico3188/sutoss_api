using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Prestamosxpersona
    {
        public int IdPrestamosxpersona { get; set; }
        public DateOnly PpFecha { get; set; }
        public int PpCantCuotas { get; set; }
        public string PpObrsevacion { get; set; }
        public string PpEstado { get; set; }
        public int PrestamoIdPrestamo { get; set; }
        public int PersonaIdPersona { get; set; }

        public virtual Persona PersonaIdPersonaNavigation { get; set; }
        public virtual Prestamo PrestamoIdPrestamoNavigation { get; set; }
    }
}
