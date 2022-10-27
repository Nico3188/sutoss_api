using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class servicioRepository : Repository<servicio>, IservicioRepository
    {
        public servicioRepository(sutossContext context) : base(context)
        {
            DataSet = context.servicios;
        }
        protected override Func<servicio, bool> PredicateAll()
        {
            return new Func<servicio, bool>(x => x.Deleted == false);
        }

        protected override Func<servicio, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<servicio, bool>(x => x.servicioId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"servicioId == {id}";
        }
    }
}
