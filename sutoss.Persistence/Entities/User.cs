using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public bool Deleted { get; set; }
        public int UserId { get; set; }
        public DateTime Stamp { get; set; }
        public string Email { get; set; }
        public int? OwnerId { get; set; }

        public virtual Owner Owner { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
