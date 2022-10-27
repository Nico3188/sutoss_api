using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class fp_contratoRepository : Repository<fp_contrato>, Ifp_contratoRepository
    {
        public fp_contratoRepository(sutossContext context) : base(context)
        {
            DataSet = context.fp_contratos;
        }
        protected override Func<fp_contrato, bool> PredicateAll()
        {
            return new Func<fp_contrato, bool>(x => x.Deleted == false);
        }

        protected override Func<fp_contrato, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<fp_contrato, bool>(x => x.fp_contratoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"fp_contratoId == {id}";
        }
    }
}
