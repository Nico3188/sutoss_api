using sutoss.Domain.Services.Domain.Repositories.Interfaces;
using sutoss.Domain.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sutoss.Domain.Services.Domain.Repositories
{
    public class HealtcareVisitDocumentRepository : Repository<HealtcareVisitDocument>, IHealtcareVisitDocumentRepository
    {
        public HealtcareVisitDocumentRepository(sutossContext context) : base(context)
        {
            DataSet = context.HealtcareVisitDocuments;
        }

        protected override string PredicateStringAll()
        {
            return "";
        }

        protected override string PredicateStringGet<TInput>(TInput id)
        {
            return $"HealtcareVisitDocumentId == {id}";
        }
    }
}
