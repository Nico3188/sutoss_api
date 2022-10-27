using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Response
{
    public class HealtcareVisitResponse
    {
        public bool Deleted { get; set; }
public int HealtcareVisitId { get; set; }
public DateTime VisitDay { get; set; }
public DateTime Stamp { get; set; }
public string Description { get; set; }
public int PetId { get; set; }

    }
}
