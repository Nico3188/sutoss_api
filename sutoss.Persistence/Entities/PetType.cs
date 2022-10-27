using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class PetType
    {
        public PetType()
        {
            Pets = new HashSet<Pet>();
        }

        public bool Deleted { get; set; }
        public int PetTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
