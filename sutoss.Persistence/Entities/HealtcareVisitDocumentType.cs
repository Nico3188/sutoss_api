using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class HealtcareVisitDocumentType
    {
        public HealtcareVisitDocumentType()
        {
            HealtcareVisitDocuments = new HashSet<HealtcareVisitDocument>();
        }

        public bool Deleted { get; set; }
        public int HealtcareVisitDocumentTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<HealtcareVisitDocument> HealtcareVisitDocuments { get; set; }
    }
}
