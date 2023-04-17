using System;
using System.Collections.Generic;

namespace Sutoss
{
    public partial class ExpereiciaLaboral
    {
        public int IdExpereiciaLaboral { get; set; }
        public string Expempresa { get; set; }
        public string Exppuesto { get; set; }
        public string Expfingreso { get; set; }
        public string Expegreso { get; set; }
        public string Exptareas { get; set; }
        public string Expmotivobaja { get; set; }
        public int PostulanteIdPostulante { get; set; }

        public virtual Postulante PostulanteIdPostulanteNavigation { get; set; }
    }
}
