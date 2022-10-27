using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class proveedorRepository : Repository<proveedor>, IproveedorRepository
    {
        public proveedorRepository(sutossContext context) : base(context)
        {
            DataSet = context.proveedores;
        }
        protected override Func<proveedor, bool> PredicateAll()
        {
            return new Func<proveedor, bool>(x => x.Deleted == false);
        }

        protected override Func<proveedor, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<proveedor, bool>(x => x.proveedorId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"proveedorId == {id}";
        }
    }
}
