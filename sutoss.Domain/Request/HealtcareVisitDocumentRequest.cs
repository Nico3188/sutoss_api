using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Request
{
    public class HealtcareVisitDocumentRequest
    {
        public int HealtcareVisitDocumentId { get; set; }
public string MimeType { get; set; }
public string Name { get; set; }
public int HealtcareVisitDocumentTypeId { get; set; }

    }
}
