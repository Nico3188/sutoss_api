using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Ganador
    {
        public int IdGanador { get; set; }
        public int PremioIdPremios { get; set; }
        public int CelebracionIdCelebracion { get; set; }

        public virtual Celebracion CelebracionIdCelebracionNavigation { get; set; }
        public virtual Premio PremioIdPremiosNavigation { get; set; }
    }
}
