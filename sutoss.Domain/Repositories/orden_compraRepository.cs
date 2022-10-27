using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class orden_compraRepository : Repository<orden_compra>, Iorden_compraRepository
    {
        public orden_compraRepository(sutossContext context) : base(context)
        {
            DataSet = context.ordenes_compra;
        }
        protected override Func<orden_compra, bool> PredicateAll()
        {
            return new Func<orden_compra, bool>(x => x.Deleted == false);
        }

        protected override Func<orden_compra, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<orden_compra, bool>(x => x.orden_compraId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"orden_compraId == {id}";
        }
    }
}
