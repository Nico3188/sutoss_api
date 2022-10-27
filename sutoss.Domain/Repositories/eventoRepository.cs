using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class eventoRepository : Repository<evento>, IeventoRepository
    {
        public eventoRepository(sutossContext context) : base(context)
        {
            DataSet = context.eventos;
        }
        protected override Func<evento, bool> PredicateAll()
        {
            return new Func<evento, bool>(x => x.Deleted == false);
        }

        protected override Func<evento, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<evento, bool>(x => x.eventoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"eventoId == {id}";
        }
    }
}
