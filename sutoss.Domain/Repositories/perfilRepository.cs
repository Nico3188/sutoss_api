using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class perfilRepository : Repository<perfil>, IperfilRepository
    {
        public perfilRepository(sutossContext context) : base(context)
        {
            DataSet = context.perfiles;
        }
        protected override Func<perfil, bool> PredicateAll()
        {
            return new Func<perfil, bool>(x => x.Deleted == false);
        }

        protected override Func<perfil, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<perfil, bool>(x => x.perfilId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"perfilId == {id}";
        }
    }
}
