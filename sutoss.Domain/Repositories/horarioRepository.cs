using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class horarioRepository : Repository<horario>, IhorarioRepository
    {
        public horarioRepository(sutossContext context) : base(context)
        {
            DataSet = context.horarios;
        }
        protected override Func<horario, bool> PredicateAll()
        {
            return new Func<horario, bool>(x => x.Deleted == false);
        }

        protected override Func<horario, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<horario, bool>(x => x.horarioId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"horarioId == {id}";
        }
    }
}
