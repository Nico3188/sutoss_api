using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class instalacionRepository : Repository<instalacion>, IinstalacionRepository
    {
        public instalacionRepository(sutossContext context) : base(context)
        {
            DataSet = context.instalaciones;
        }
        protected override Func<instalacion, bool> PredicateAll()
        {
            return new Func<instalacion, bool>(x => x.Deleted == false);
        }

        protected override Func<instalacion, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<instalacion, bool>(x => x.instalacionId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"instalacionId == {id}";
        }
    }
}
