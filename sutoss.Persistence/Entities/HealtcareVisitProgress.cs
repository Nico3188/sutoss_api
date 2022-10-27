using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class HealtcareVisitProgress
    {
        public int HealtcareVisitProgressId { get; set; }
        public int HealtcareVisitId { get; set; }
        public int HealtcareVisitTypeId { get; set; }

        public virtual HealtcareVisit HealtcareVisit { get; set; }
        public virtual HealtcareVisitType HealtcareVisitType { get; set; }
    }
}
