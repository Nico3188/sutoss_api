using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class HealtcareVisitType
    {
        public HealtcareVisitType()
        {
            HealtcareVisitProgresses = new HashSet<HealtcareVisitProgress>();
        }

        public bool Deleted { get; set; }
        public int HealtcareVisitTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HealtcareVisitProgress> HealtcareVisitProgresses { get; set; }
    }
}
