using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Response
{
    public class UserResponse
    {
        public bool Deleted { get; set; }
public int UserId { get; set; }
public DateTime Stamp { get; set; }
public string UserName { get; set; }
public string Hash { get; set; }

    }
}
