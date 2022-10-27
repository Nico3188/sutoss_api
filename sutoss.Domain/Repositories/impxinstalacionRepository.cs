using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class impxinstalacionRepository : Repository<impxinstalacion>, IimpxinstalacionRepository
    {
        public impxinstalacionRepository(sutossContext context) : base(context)
        {
            DataSet = context.impxinstalaciones;
        }
        protected override Func<impxinstalacion, bool> PredicateAll()
        {
            return new Func<impxinstalacion, bool>(x => x.Deleted == false);
        }

        protected override Func<impxinstalacion, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<impxinstalacion, bool>(x => x.impxinstalacionId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"impxinstalacionId == {id}";
        }
    }
}
