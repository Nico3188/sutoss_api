using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class BundleRepository : Repository<Bundle>, IBundleRepository
    {
        public BundleRepository(sutossContext context) : base(context)
        {
            DataSet = context.Bundles;
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"BundleId == {id}";
        }
    }
}
