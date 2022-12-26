using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Persona
    {
        public Persona()
        {
            Alquilers = new HashSet<Alquiler>();
            Celebracions = new HashSet<Celebracion>();
            Contratos = new HashSet<Contrato>();
            Designacions = new HashSet<Designacion>();
            InversePersonaIdPersonaNavigation = new HashSet<Persona>();
            Prestamosxpersonas = new HashSet<Prestamosxpersona>();
            Suscripcions = new HashSet<Suscripcion>();
        }

        public int IdPersona { get; set; }
        public int PerDni { get; set; }
        public string PerNombre { get; set; }
        public int? PerCuit { get; set; }
        public string PerDomicilio { get; set; }
        public string Pertelefono { get; set; }
        public string PerEstadocivil { get; set; }
        public string PerEsposa { get; set; }
        public string PerHijos { get; set; }
        public int? PerHijosCant { get; set; }
        public string PerNombreHijos { get; set; }
        public int PerNafiliadio { get; set; }
        public string PerTipo { get; set; }
        public string PerPuesto { get; set; }
        public int PerAntiguedad { get; set; }
        public int PerEdad { get; set; }
        public int PersonaIdPersona { get; set; }

        public virtual Persona PersonaIdPersonaNavigation { get; set; }
        public virtual ICollection<Alquiler> Alquilers { get; set; }
        public virtual ICollection<Celebracion> Celebracions { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Designacion> Designacions { get; set; }
        public virtual ICollection<Persona> InversePersonaIdPersonaNavigation { get; set; }
        public virtual ICollection<Prestamosxpersona> Prestamosxpersonas { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
