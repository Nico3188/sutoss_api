using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Cheklist
    {
        public Cheklist()
        {
            Checkxcontratos = new HashSet<Checkxcontrato>();
        }

        public int IdChecklist { get; set; }
        public string ChCodigo { get; set; }
        public string ChNombre { get; set; }
        public string ChDescripcion { get; set; }
        public string ChDocumento { get; set; }

        public virtual ICollection<Checkxcontrato> Checkxcontratos { get; set; }
    }
}
