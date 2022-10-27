using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class multaxcontratoRepository : Repository<multaxcontrato>, ImultaxcontratoRepository
    {
        public multaxcontratoRepository(sutossContext context) : base(context)
        {
            DataSet = context.multasxcontrado;
        }
        protected override Func<multaxcontrato, bool> PredicateAll()
        {
            return new Func<multaxcontrato, bool>(x => x.Deleted == false);
        }

        protected override Func<multaxcontrato, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<multaxcontrato, bool>(x => x.multaxcontratoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"multaxcontratoId == {id}";
        }
    }
}
