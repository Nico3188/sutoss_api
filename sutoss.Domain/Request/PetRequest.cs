using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Request
{
    public class PetRequest
    {
        public bool Deleted { get; set; }
public int PetId { get; set; }
public string Name { get; set; }
public int OwnerId { get; set; }
public int PetTypeId { get; set; }

    }
}
