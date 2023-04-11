using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class Conocimiento
    {
        public int IdConocimiento { get; set; }
        public string Conconocimiento { get; set; }
        public string Condescripcion { get; set; }
        /// <summary>
        /// junior / intermedio / avanzado
        /// </summary>
        public string Connivel { get; set; }
        public int PostulanteIdPostulante { get; set; }

        public virtual Postulante PostulanteIdPostulanteNavigation { get; set; }
    }
}
