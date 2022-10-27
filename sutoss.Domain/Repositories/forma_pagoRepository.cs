using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class forma_pagoRepository : Repository<forma_pago>, Iforma_pagoRepository
    {
        public forma_pagoRepository(sutossContext context) : base(context)
        {
            DataSet = context.fromas_pago;
        }
        protected override Func<forma_pago, bool> PredicateAll()
        {
            return new Func<forma_pago, bool>(x => x.Deleted == false);
        }

        protected override Func<forma_pago, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<forma_pago, bool>(x => x.forma_pagoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"forma_pagoId == {id}";
        }
    }
}
