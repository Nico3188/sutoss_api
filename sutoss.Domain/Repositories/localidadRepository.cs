using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class localidadRepository : Repository<localidad>, IlocalidadRepository
    {
        public localidadRepository(sutossContext context) : base(context)
        {
            DataSet = context.localidades;
        }
        protected override Func<localidad, bool> PredicateAll()
        {
            return new Func<localidad, bool>(x => x.Deleted == false);
        }

        protected override Func<localidad, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<localidad, bool>(x => x.localidadId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"localidadId == {id}";
        }
    }
}
