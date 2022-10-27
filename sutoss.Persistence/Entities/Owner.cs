using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Owner
    {
        public Owner()
        {
            Pets = new HashSet<Pet>();
            Users = new HashSet<User>();
        }

        public bool Deleted { get; set; }
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cbu { get; set; }
        public DateTime? Birthdate { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
