using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class personaRepository : Repository<persona>, IpersonaRepository
    {
        public personaRepository(sutossContext context) : base(context)
        {
            DataSet = context.personas;
        }
        protected override Func<persona, bool> PredicateAll()
        {
            return new Func<persona, bool>(x => x.Deleted == false);
        }

        protected override Func<persona, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<persona, bool>(x => x.personaId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"personaId == {id}";
        }
    }
}
