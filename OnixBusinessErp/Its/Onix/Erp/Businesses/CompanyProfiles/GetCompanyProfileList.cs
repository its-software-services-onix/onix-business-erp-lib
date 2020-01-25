using System;
using System.Linq;
using System.Linq.Expressions;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
    public class GetCompanyProfileList : GetListOperation
    {      
        protected override Type GetModelType()
        {
            return typeof(CompanyProfile);
        }

        private IQueryable<CompanyProfile> GetQuery(ParameterExpression startParam, Expression expr)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;
            var query = ctx.CompanyProfiles;

            var lambda = Expression.Lambda<Func<CompanyProfile, bool>>(expr, startParam);
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
