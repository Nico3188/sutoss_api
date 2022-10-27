using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Request
{
    public class ServiceItemRequest
    {
        public bool Deleted { get; set; }
public int ServiceItemId { get; set; }
public string Name { get; set; }
public double Price { get; set; }

    }
}
