using System;
using System.Linq;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;

namespace Its.Onix.Erp.Businesses.Masters
{
    public class GetMasterList : GetListOperation
    {      
        protected override IQueryable<BaseModel> Query()
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;
            var results = ctx.Masters;

            return results;
        }

        protected override int GetTotalRecord()
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;
            int total = ctx.Masters.Count();

            return total;
        }
    }
}
