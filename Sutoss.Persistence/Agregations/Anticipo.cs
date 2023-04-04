using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Anticipo
    {
        public string PerNombre => PersonaIdPersonaNavigation != null? PersonaIdPersonaNavigation.PerNombre : "";
        public int? PerNafiliadio => PersonaIdPersonaNavigation != null?  PersonaIdPersonaNavigation.PerNafiliadio : null;

    }
}
