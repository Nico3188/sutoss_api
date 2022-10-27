using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class diaRepository : Repository<dia>, IdiaRepository
    {
        public diaRepository(sutossContext context) : base(context)
        {
            DataSet = context.dias;
        }
        protected override Func<dia, bool> PredicateAll()
        {
            return new Func<dia, bool>(x => x.Deleted == false);
        }

        protected override Func<dia, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<dia, bool>(x => x.diaId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"diaId == {id}";
        }
    }
}
