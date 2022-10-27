using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class premioRepository : Repository<premio>, IpremioRepository
    {
        public premioRepository(sutossContext context) : base(context)
        {
            DataSet = context.premios;
        }
        protected override Func<premio, bool> PredicateAll()
        {
            return new Func<premio, bool>(x => x.Deleted == false);
        }

        protected override Func<premio, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<premio, bool>(x => x.premioId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"premioId == {id}";
        }
    }
}
