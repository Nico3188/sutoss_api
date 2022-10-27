using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class facturaRepository : Repository<factura>, IfacturaRepository
    {
        public facturaRepository(sutossContext context) : base(context)
        {
            DataSet = context.facturas;
        }
        protected override Func<factura, bool> PredicateAll()
        {
            return new Func<factura, bool>(x => x.Deleted == false);
        }

        protected override Func<factura, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<factura, bool>(x => x.facturaId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"facturaId == {id}";
        }
    }
}
