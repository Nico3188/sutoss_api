﻿using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Idioma
    {
        public int IdIdioma { get; set; }
        public string Idiidioma { get; set; }
        public string Idiinstitucion { get; set; }
        public string Idiescritura { get; set; }
        public string Idilectura { get; set; }
        public string Idiconversacion { get; set; }
        public int PersonaIdPersona { get; set; }

        public virtual Persona PersonaIdPersonaNavigation { get; set; }
    }
}