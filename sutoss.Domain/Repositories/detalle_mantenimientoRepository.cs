using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class detalle_mantenimientoRepository : Repository<detalle_mantenimiento>, Idetalle_mantenimientoRepository
    {
        public detalle_mantenimientoRepository(sutossContext context) : base(context)
        {
            DataSet = context.detalle_mantenimientos;
        }
        protected override Func<detalle_mantenimiento, bool> PredicateAll()
        {
            return new Func<detalle_mantenimiento, bool>(x => x.Deleted == false);
        }

        protected override Func<detalle_mantenimiento, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<detalle_mantenimiento, bool>(x => x.detalle_mantenimientoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"detalle_mantenimientoId == {id}";
        }
    }
}
