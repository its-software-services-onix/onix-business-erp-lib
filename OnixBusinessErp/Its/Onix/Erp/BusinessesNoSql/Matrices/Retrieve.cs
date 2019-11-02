using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Core.Commons.Table;
using System.Collections.Generic;

namespace Its.Onix.Erp.Businesses.Matrices
{
    public class Retrieve : BusinessOperationBase, IBusinessOperationQuery<MMetricWrapper>
    {
        public IEnumerable<MMetricWrapper> Apply(MMetricWrapper dat, CTable param)
        {
            var ctx = GetNoSqlContext();
            var metrics = ctx.GetObjectList<MMetricWrapper>("matrics");
            return metrics;
        }
    }
}
