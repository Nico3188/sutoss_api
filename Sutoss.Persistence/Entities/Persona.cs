using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Persona
    {
        public Persona()
        {
            Alquilers = new HashSet<Alquiler>();
            Anticipos = new HashSet<Anticipo>();
            Celebracions = new HashSet<Celebracion>();
            Contratos = new HashSet<Contrato>();
            Designacions = new HashSet<Designacion>();
            Familiars = new HashSet<Familiar>();
            Prestamosxpersonas = new HashSet<Prestamosxpersona>();
            Suscripcions = new HashSet<Suscripcion>();
        }

        public int IdPersona { get; set; }
        public int PerDni { get; set; }
        public string PerNombre { get; set; }
        public string PerDomicilio { get; set; }
        public string Pertelefono { get; set; }
        public string PerEstadocivil { get; set; }
        public int PerNafiliadio { get; set; }
        public string PerTipo { get; set; }
        public string PerPuesto { get; set; }
        public int? PerAntiguedad { get; set; }
        public int? PerEdad { get; set; }

        public virtual ICollection<Alquiler> Alquilers { get; set; }
        public virtual ICollection<Anticipo> Anticipos { get; set; }
        public virtual ICollection<Celebracion> Celebracions { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Designacion> Designacions { get; set; }
        public virtual ICollection<Familiar> Familiars { get; set; }
        public virtual ICollection<Prestamosxpersona> Prestamosxpersonas { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
