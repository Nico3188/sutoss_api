using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class impuestoRepository : Repository<impuesto>, IimpuestoRepository
    {
        public impuestoRepository(sutossContext context) : base(context)
        {
            DataSet = context.impuestos;
        }
        protected override Func<impuesto, bool> PredicateAll()
        {
            return new Func<impuesto, bool>(x => x.Deleted == false);
        }

        protected override Func<impuesto, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<impuesto, bool>(x => x.impuestoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"impuestoId == {id}";
        }
    }
}
