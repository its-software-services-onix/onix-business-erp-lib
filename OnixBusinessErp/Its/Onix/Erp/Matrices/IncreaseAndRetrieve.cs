using System;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.Matrices
{
    public class IncreaseAndRetrieve : BusinessOperationBase, IBusinessOperationManipulate<MMetric>
    {
        public int Apply(MMetric dat)
        {
            string key = dat.Key;
            string path = string.Format("matrics/{0}", key);

            var ctx = GetNoSqlContext();
            var metric = ctx.GetObjectByKey<MMetric>(path);
            if (metric == null)
            {
                metric = dat;
            }
            else
            {
                metric.Value = metric.Value + dat.Value;
            }
            metric.LastMaintDate = DateTime.Now;
            ctx.PutData(path, "Value", metric);
            return metric.Value;
        }
    }
}
