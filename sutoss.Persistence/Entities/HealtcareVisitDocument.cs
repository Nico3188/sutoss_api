using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class HealtcareVisitDocument
    {
        public int HealtcareVisitDocumentId { get; set; }
        public string MimeType { get; set; }
        public string Name { get; set; }
        public int HealtcareVisitDocumentTypeId { get; set; }

        public virtual HealtcareVisitDocumentType HealtcareVisitDocumentType { get; set; }
    }
}
