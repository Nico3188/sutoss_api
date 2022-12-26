using Sutoss.Domain.Services.Domain.Repositories.Interfaces;
using Sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Repositories
{
    public class CuotaPrestamoRepository : Repository<CuotaPrestamo>, ICuotaPrestamoRepository
    {
        public CuotaPrestamoRepository(SutossContext context) : base(context)
        {
            DataSet = context.CuotaPrestamos;
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"IdCuotaPrestamo == {id}";
        }
    }
}