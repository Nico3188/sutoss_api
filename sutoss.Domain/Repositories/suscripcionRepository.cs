using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class suscripcionRepository : Repository<suscripcion>, IsuscripcionRepository
    {
        public suscripcionRepository(sutossContext context) : base(context)
        {
            DataSet = context.suscripciones;
        }
        protected override Func<suscripcion, bool> PredicateAll()
        {
            return new Func<suscripcion, bool>(x => x.Deleted == false);
        }

        protected override Func<suscripcion, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<suscripcion, bool>(x => x.suscripcionId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"suscripcionId == {id}";
        }
    }
}
