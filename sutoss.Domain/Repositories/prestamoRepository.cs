using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class prestamoRepository : Repository<prestamo>, IprestamoRepository
    {
        public prestamoRepository(sutossContext context) : base(context)
        {
            DataSet = context.pretamos;
        }
        protected override Func<prestamo, bool> PredicateAll()
        {
            return new Func<prestamo, bool>(x => x.Deleted == false);
        }

        protected override Func<prestamo, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<prestamo, bool>(x => x.prestamoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"prestamoId == {id}";
        }
    }
}
