using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class ServiceItem
    {
        public ServiceItem()
        {
            Bundles = new HashSet<Bundle>();
        }

        public bool Deleted { get; set; }
        public int ServiceItemId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Bundle> Bundles { get; set; }
    }
}
