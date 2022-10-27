using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class vinculoRepository : Repository<vinculo>, IvinculoRepository
    {
        public vinculoRepository(sutossContext context) : base(context)
        {
            DataSet = context.vinculos;
        }
        protected override Func<vinculo, bool> PredicateAll()
        {
            return new Func<vinculo, bool>(x => x.Deleted == false);
        }

        protected override Func<vinculo, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<vinculo, bool>(x => x.vinculoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"vinculoId == {id}";
        }
    }
}
