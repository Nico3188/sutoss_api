using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Payment
    {
        public int Deleted { get; set; }
        public int PaymentId { get; set; }
        public DateTime Stamp { get; set; }
        public double Amount { get; set; }
        public bool OutOfTerm { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
