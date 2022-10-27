using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class PetService
    {
        public int PetServiceId { get; set; }
        public int PetId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Stamp { get; set; }
        public int ExpirationDay { get; set; }
    }
}
