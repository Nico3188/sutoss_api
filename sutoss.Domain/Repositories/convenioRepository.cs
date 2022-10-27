using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class convenioRepository : Repository<Convenio>, IConvenioRepository
    {
        public convenioRepository(sutossContext context) : base(context)
        {
            DataSet = context.Convenios;
        }
        
        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"convenioId == {id}";
        }
    }
}
