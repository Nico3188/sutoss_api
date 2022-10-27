using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Response
{
    public class RefundResponse
    {
        public bool Deleted { get; set; }
public int RefundId { get; set; }
public double Amount { get; set; }
public DateTime Stamp { get; set; }
public int HealtcareVisitId { get; set; }

    }
}
