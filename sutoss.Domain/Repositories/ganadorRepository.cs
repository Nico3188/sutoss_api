using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class ganadorRepository : Repository<ganador>, IganadorRepository
    {
        public ganadorRepository(sutossContext context) : base(context)
        {
            DataSet = context.ganadores;
        }
        protected override Func<ganador, bool> PredicateAll()
        {
            return new Func<ganador, bool>(x => x.Deleted == false);
        }

        protected override Func<ganador, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<ganador, bool>(x => x.ganadorId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"ganadorId == {id}";
        }
    }
}
