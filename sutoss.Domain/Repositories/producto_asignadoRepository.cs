using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class producto_asignadoRepository : Repository<producto_asignado>, Iproducto_asignadoRepository
    {
        public producto_asignadoRepository(sutossContext context) : base(context)
        {
            DataSet = context.productos_asignados;
        }
        protected override Func<producto_asignado, bool> PredicateAll()
        {
            return new Func<producto_asignado, bool>(x => x.Deleted == false);
        }

        protected override Func<producto_asignado, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<producto_asignado, bool>(x => x.producto_asignadoId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"producto_asignadoId == {id}";
        }
    }
}
