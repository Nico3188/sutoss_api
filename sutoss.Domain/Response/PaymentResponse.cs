using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Response
{
    public class PaymentResponse
    {
        public int Deleted { get; set; }
public int PaymentId { get; set; }
public DateTime Stamp { get; set; }
public double Amount { get; set; }
public bool OutOfTerm { get; set; }
public DateTime PaymentDate { get; set; }

    }
}
