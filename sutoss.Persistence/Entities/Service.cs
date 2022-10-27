using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Service
    {
        public Service()
        {
            Bundles = new HashSet<Bundle>();
        }

        public bool Deleted { get; set; }
        public int ServiceId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Bundle> Bundles { get; set; }
    }
}
