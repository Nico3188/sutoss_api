using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class enfermedadRepository : Repository<enfermedad>, IenfermedadRepository
    {
        public enfermedadRepository(sutossContext context) : base(context)
        {
            DataSet = context.enfermedades;
        }
        protected override Func<enfermedad, bool> PredicateAll()
        {
            return new Func<enfermedad, bool>(x => x.Deleted == false);
        }

        protected override Func<enfermedad, bool> PredicateGet<TInput>(TInput id)
        {
            return new Func<enfermedad, bool>(x => x.enfermedadId == int.Parse(id.ToString()));
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"enfermedadId == {id}";
        }
    }
}
