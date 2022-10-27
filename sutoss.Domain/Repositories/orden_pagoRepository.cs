using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class orden_pagoRepository : Repository<orden_pago>, Iorden_pagoRepository
    {
        public orden_pagoRepository(sutossContext context) : base(context)
        {
            DataSet = context.ordenes_pago;
        }
        protected override Func<orden_pago, bool> PredicateAll()
        {
            return new Func<orden_pago, bool>(x => x.Deleted == false);
        }

        protected override Func<orden_pago, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<orden_pago, bool>(x => x.orden_pagoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"orden_pagoId == {id}";
        }
    }
}
