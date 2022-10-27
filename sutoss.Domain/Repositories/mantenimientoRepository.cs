using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class mantenimientoRepository : Repository<mantenimiento>, ImantenimientoRepository
    {
        public mantenimientoRepository(sutossContext context) : base(context)
        {
            DataSet = context.mantenimientos;
        }
        protected override Func<mantenimiento, bool> PredicateAll()
        {
            return new Func<mantenimiento, bool>(x => x.Deleted == false);
        }

        protected override Func<mantenimiento, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<mantenimiento, bool>(x => x.mantenimientoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"mantenimientoId == {id}";
        }
    }
}
