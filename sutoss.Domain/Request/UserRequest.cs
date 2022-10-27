using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Request
{
    public class UserRequest
    {
        public bool Deleted { get; set; }
        public int UserId { get; set; }
        public DateTime Stamp { get; set; }
        public string UserName { get; set; }
        public string Hash { get; set; }

    }
}
