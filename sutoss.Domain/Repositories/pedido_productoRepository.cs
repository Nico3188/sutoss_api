using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class pedido_productoRepository : Repository<pedido_producto>, Ipedido_productoRepository
    {
        public pedido_productoRepository(sutossContext context) : base(context)
        {
            DataSet = context.pedidos_productos;
        }
        protected override Func<pedido_producto, bool> PredicateAll()
        {
            return new Func<pedido_producto, bool>(x => x.Deleted == false);
        }

        protected override Func<pedido_producto, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<pedido_producto, bool>(x => x.pedido_productoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"pedido_productoId == {id}";
        }
    }
}
