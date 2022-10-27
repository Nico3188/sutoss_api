using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class CuotaRepository : Repository<Cuota>, ICuotaRepository
    {
        public CuotaRepository(sutossContext context) : base(context)
        {
            DataSet = context.Cuotas;
        }
        
        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"cuotaId == {id}";
        }
    }
}
