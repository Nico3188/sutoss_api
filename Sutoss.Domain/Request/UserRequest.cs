using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Request
{
    public class UserRequest
    {
        public int IdUser { get; set; }
public string Usernombre { get; set; }
public string Userrol { get; set; }
public string Hash { get; set; }
public string Usermail { get; set; }

    }
}
