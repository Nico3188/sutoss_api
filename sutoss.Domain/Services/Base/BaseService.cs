using sutoss.Domain.Services.Domain.Filters;
using sutoss.Domain.Services.Domain.Filters.Base;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace sutoss.Domain.Services.Domain.Services.Base
{
    public abstract class BaseService
    {
        public BaseService()
        {

        }


        public IQueryable<T> ApplyFilterAndPagination<T>(IQueryable<T> dataSet, int s, string q, int l)
        {
            var filter = GetFilterExpression(q);
            var filterString = filter.GetStringValue();
            if (!string.IsNullOrEmpty(filterString))
            {
                dataSet = dataSet.Where(filter.GetStringValue());
            }
            if (!filter.All)
            {
                dataSet = dataSet.Skip(s * l).Take(l);
            }

            return dataSet;
        }

        public Expression GetFilterExpression(string q)
        {
            return !string.IsNullOrEmpty(q) ? FilterBuilder.BuildFilterFromBase64<Expression>(q) : new Expression();
        }
    }
}
