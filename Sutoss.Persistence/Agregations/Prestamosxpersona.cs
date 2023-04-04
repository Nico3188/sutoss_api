using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Prestamosxpersona
    {
        public string PerNombre => PersonaIdPersonaNavigation != null? PersonaIdPersonaNavigation.PerNombre : "";
        public string PerTipo => PersonaIdPersonaNavigation != null? PersonaIdPersonaNavigation.PerTipo : "activo";
        public int? PerNafiliadio => PersonaIdPersonaNavigation != null?  PersonaIdPersonaNavigation.PerNafiliadio : null;

    }
}
