using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class cuota_ppRepository : Repository<cuota_pp>, Icuota_ppRepository
    {
        public cuota_ppRepository(sutossContext context) : base(context)
        {
            DataSet = context.cuotas_pp;
        }
        protected override Func<cuota_pp, bool> PredicateAll()
        {
            return new Func<cuota_pp, bool>(x => x.Deleted == false);
        }

        protected override Func<cuota_pp, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<cuota_pp, bool>(x => x.cuota_ppId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"cuota_ppId == {id}";
        }
    }
}
