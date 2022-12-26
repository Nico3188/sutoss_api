using Sutoss.Domain.Services.Domain.Repositories.Interfaces;
using Sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Repositories
{
    public class BeneficioRepository : Repository<Beneficio>, IBeneficioRepository
    {
        public BeneficioRepository(SutossContext context) : base(context)
        {
            DataSet = context.Beneficios;
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"IdBeneficio == {id}";
        }
    }
}
