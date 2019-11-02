using System;
using System.Linq;
using System.Linq.Expressions;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
    public class GetMasterList : GetListOperation
    {      
        protected override Type GetModelType()
        {
            return typeof(Master);
        }

        private IQueryable<Master> GetQuery(ParameterExpression startParam, Expression expr)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;
            var query = ctx.Masters;

            var lambda = Expression.Lambda<Func<Master, bool>>(expr, startParam);
            var results = query.Where(lambda);

            return results;      
        }

        protected override IQueryable<BaseModel> Query(ParameterExpression startParam, Expression expr)
        {
            var results =  GetQuery(startParam, expr);
            return results;
        }

        protected override int GetTotalRecord(ParameterExpression startParam, Expression expr)
        {
            var results =  GetQuery(startParam, expr);
            int total = results.Count();

            return total;
        }
    }
}
