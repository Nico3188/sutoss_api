using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class cuota_anticipoRepository : Repository<cuota_anticipo>, Icuota_anticipoRepository
    {
        public cuota_anticipoRepository(sutossContext context) : base(context)
        {
            DataSet = context.cuotas_anticipos;
        }
        protected override Func<cuota_anticipo, bool> PredicateAll()
        {
            return new Func<cuota_anticipo, bool>(x => x.Deleted == false);
        }

        protected override Func<cuota_anticipo, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<cuota_anticipo, bool>(x => x.cuota_anticipoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"cuota_anticipoId == {id}";
        }
    }
}
