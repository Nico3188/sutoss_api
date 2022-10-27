using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class turnoRepository : Repository<turno>, IturnoRepository
    {
        public turnoRepository(sutossContext context) : base(context)
        {
            DataSet = context.turnos;
        }
        protected override Func<turno, bool> PredicateAll()
        {
            return new Func<turno, bool>(x => x.Deleted == false);
        }

        protected override Func<turno, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<turno, bool>(x => x.turnoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"turnoId == {id}";
        }
    }
}
