using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Bundle
    {
        public int BundleId { get; set; }
        public int ServiceId { get; set; }
        public int ServiceItemId { get; set; }

        public virtual Service Service { get; set; }
        public virtual ServiceItem ServiceItem { get; set; }
    }
}
