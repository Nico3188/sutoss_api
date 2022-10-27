using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class provinciaRepository : Repository<provincia>, IprovinciaRepository
    {
        public provinciaRepository(sutossContext context) : base(context)
        {
            DataSet = context.provincias;
        }
        protected override Func<provincia, bool> PredicateAll()
        {
            return new Func<provincia, bool>(x => x.Deleted == false);
        }

        protected override Func<provincia, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<provincia, bool>(x => x.provinciaId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"provinciaId == {id}";
        }
    }
}
