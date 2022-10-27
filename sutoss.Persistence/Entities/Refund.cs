using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Refund
    {
        public bool Deleted { get; set; }
        public int RefundId { get; set; }
        public double Amount { get; set; }
        public DateTime Stamp { get; set; }
        public int HealtcareVisitId { get; set; }

        public virtual HealtcareVisit HealtcareVisit { get; set; }
    }
}
