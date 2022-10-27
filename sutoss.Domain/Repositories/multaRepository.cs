using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class multaRepository : Repository<multa>, ImultaRepository
    {
        public multaRepository(sutossContext context) : base(context)
        {
            DataSet = context.multas;
        }
        protected override Func<multa, bool> PredicateAll()
        {
            return new Func<multa, bool>(x => x.Deleted == false);
        }

        protected override Func<multa, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<multa, bool>(x => x.multaId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"multaId == {id}";
        }
    }
}
