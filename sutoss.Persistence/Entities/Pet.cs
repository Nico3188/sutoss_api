using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Pet
    {
        public Pet()
        {
            HealtcareVisits = new HashSet<HealtcareVisit>();
        }

        public bool Deleted { get; set; }
        public int PetId { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public int PetTypeId { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual PetType PetType { get; set; }
        public virtual ICollection<HealtcareVisit> HealtcareVisits { get; set; }
    }
}
