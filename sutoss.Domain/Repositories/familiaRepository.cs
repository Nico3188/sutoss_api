using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class familiaRepository : Repository<familia>, IfamiliaRepository
    {
        public familiaRepository(sutossContext context) : base(context)
        {
            DataSet = context.familias;
        }
        protected override Func<familia, bool> PredicateAll()
        {
            return new Func<familia, bool>(x => x.Deleted == false);
        }

        protected override Func<familia, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<familia, bool>(x => x.familiaId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"familiaId == {id}";
        }
    }
}
