using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class prestamoxpersonaRepository : Repository<prestamoxpersona>, IprestamoxpersonaRepository
    {
        public prestamoxpersonaRepository(sutossContext context) : base(context)
        {
            DataSet = context.pretamosxpersonas;
        }
        protected override Func<prestamoxpersona, bool> PredicateAll()
        {
            return new Func<prestamoxpersona, bool>(x => x.Deleted == false);
        }

        protected override Func<prestamoxpersona, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<prestamoxpersona, bool>(x => x.prestamoxpersonaId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"prestamoxpersonaId == {id}";
        }
    }
}
