using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class HealtcareVisitRequest
    {
        public bool Deleted { get; set; }
public int HealtcareVisitId { get; set; }
public DateTime VisitDay { get; set; }
public DateTime Stamp { get; set; }
public string Description { get; set; }
public int PetId { get; set; }

    }
}
