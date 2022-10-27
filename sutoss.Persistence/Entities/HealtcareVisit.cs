using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class HealtcareVisit
    {
        public HealtcareVisit()
        {
            HealtcareVisitProgresses = new HashSet<HealtcareVisitProgress>();
            Refunds = new HashSet<Refund>();
        }

        public bool Deleted { get; set; }
        public int HealtcareVisitId { get; set; }
        public DateTime VisitDay { get; set; }
        public DateTime Stamp { get; set; }
        public string Description { get; set; }
        public int PetId { get; set; }

        public virtual Pet Pet { get; set; }
        public virtual ICollection<HealtcareVisitProgress> HealtcareVisitProgresses { get; set; }
        public virtual ICollection<Refund> Refunds { get; set; }
    }
}
