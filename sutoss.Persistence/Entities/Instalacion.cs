using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Instalacion
    {
        public Instalacion()
        {
            Alquilers = new HashSet<Alquiler>();
            Designacions = new HashSet<Designacion>();
            Gastoxinsts = new HashSet<Gastoxinst>();
            Impxinstalacions = new HashSet<Impxinstalacion>();
            Mantenimientos = new HashSet<Mantenimiento>();
            ProductoAsignados = new HashSet<ProductoAsignado>();
        }

        public int IdInstalacion { get; set; }
        public string INombre { get; set; }
        public string IMetroscuadrados { get; set; }
        public string IDescripcion { get; set; }
        public int LocalidadIdLocalidad { get; set; }

        public virtual Localidad LocalidadIdLocalidadNavigation { get; set; }
        public virtual ICollection<Alquiler> Alquilers { get; set; }
        public virtual ICollection<Designacion> Designacions { get; set; }
        public virtual ICollection<Gastoxinst> Gastoxinsts { get; set; }
        public virtual ICollection<Impxinstalacion> Impxinstalacions { get; set; }
        public virtual ICollection<Mantenimiento> Mantenimientos { get; set; }
        public virtual ICollection<ProductoAsignado> ProductoAsignados { get; set; }
    }
}
