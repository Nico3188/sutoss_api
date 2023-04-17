using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Postulante
    {
        public Postulante()
        {
            Conocimientos = new HashSet<Conocimiento>();
            ExpereiciaLaborals = new HashSet<ExpereiciaLaboral>();
            Idiomas = new HashSet<Idioma>();
        }

        public int IdPostulante { get; set; }
        public int PersonaIdPersona { get; set; }
        public int? PostDni { get; set; }
        public string PostNombre { get; set; }
        public string PostApellido { get; set; }
        public DateTime? PostFnac { get; set; }
        public string PostLugNac { get; set; }
        public string PostNacionalidad { get; set; }
        public string Postdomicilio { get; set; }
        public int? Postel { get; set; }
        public string Postcorreo { get; set; }
        public string PostEstcivil { get; set; }
        /// <summary>
        /// SI/No
        /// </summary>
        public string PostRegConducir { get; set; }
        public string PostCategoriareg { get; set; }
        public string PostNivelestu { get; set; }
        public string PostNombreinst { get; set; }
        /// <summary>
        /// finalizado / incompleto / cursando
        /// 
        /// </summary>
        public string PostNivelalcanzado { get; set; }
        public string PostTituloobt { get; set; }
        public int? Postnumsolicitud { get; set; }
        public DateTime? Postfsolicitud { get; set; }
        public string Postvinculoafil { get; set; }

        public virtual Persona PersonaIdPersonaNavigation { get; set; }
        public virtual ICollection<Conocimiento> Conocimientos { get; set; }
        public virtual ICollection<ExpereiciaLaboral> ExpereiciaLaborals { get; set; }
        public virtual ICollection<Idioma> Idiomas { get; set; }
    }
}
