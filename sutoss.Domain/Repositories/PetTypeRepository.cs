using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class PetTypeRepository : Repository<PetType>, IPetTypeRepository
    {
        public PetTypeRepository(sutossContext context) : base(context)
        {
            DataSet = context.PetTypes;
        }
        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"PetTypeId == {id}";
        }
    }
}
