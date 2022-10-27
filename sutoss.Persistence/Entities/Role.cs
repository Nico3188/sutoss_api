using System;
using System.Collections.Generic;

namespace sutoss
{
    public partial class Role
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public bool Deleted { get; set; }
        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
