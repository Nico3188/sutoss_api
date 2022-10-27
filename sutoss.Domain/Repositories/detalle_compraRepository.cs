using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class detalle_compraRepository : Repository<Detalle_Compra>, Idetalle_compraRepository
    {
        public detalle_compraRepository(sutossContext context) : base(context)
        {
            DataSet = context.detalle_compras;
        }


        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"detalle_compraId == {id}";
        }
    }
}
