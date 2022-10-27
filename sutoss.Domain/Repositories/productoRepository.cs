using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class productoRepository : Repository<producto>, IproductoRepository
    {
        public productoRepository(sutossContext context) : base(context)
        {
            DataSet = context.productos;
        }
        protected override Func<producto, bool> PredicateAll()
        {
            return new Func<producto, bool>(x => x.Deleted == false);
        }

        protected override Func<producto, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<producto, bool>(x => x.productoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"productoId == {id}";
        }
    }
}
