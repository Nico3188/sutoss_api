using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class detalle_facturaRepository : Repository<detalle_factura>, Idetalle_facturaRepository
    {
        public detalle_facturaRepository(sutossContext context) : base(context)
        {
            DataSet = context.detalle_facturas;
        }
        protected override Func<detalle_factura, bool> PredicateAll()
        {
            return new Func<detalle_factura, bool>(x => x.Deleted == false);
        }

        protected override Func<detalle_factura, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<detalle_factura, bool>(x => x.detalle_facturaId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"detalle_facturaId == {id}";
        }
    }
}
