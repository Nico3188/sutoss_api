using Sutoss.Domain.Services.Domain.Repositories.Interfaces;
using Sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Repositories
{
    public class MultaxcontratoRepository : Repository<Multaxcontrato>, IMultaxcontratoRepository
    {
        public MultaxcontratoRepository(SutossContext context) : base(context)
        {
            DataSet = context.Multaxcontratos;
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"IdMultaxcontrato == {id}";
        }
    }
}
