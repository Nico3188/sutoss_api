using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class HealtcareVisitTypeRequest
    {
        public bool Deleted { get; set; }
public int HealtcareVisitTypeId { get; set; }
public string Name { get; set; }

    }
}