using Sutoss.Domain.Services.Domain.Repositories.Interfaces;
using Sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sutoss.Domain.Services.Domain.Repositories
{
    public class DesignacionRepository : Repository<Designacion>, IDesignacionRepository
    {
        public DesignacionRepository(SutossContext context) : base(context)
        {
            DataSet = context.Designacions;
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"IdDesignacion == {id}";
        }
    }
}
