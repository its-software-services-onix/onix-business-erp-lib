using System.Collections.Generic;

using Its.Onix.Core.Caches;
using Its.Onix.Core.Business;
using Its.Onix.Core.Factories;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Caches
{
    public class CacheMetrics : CacheBase
    {
        private IBusinessOperationQuery<MMetricWrapper> opr;

        public CacheMetrics()
        {
            opr = (IBusinessOperationQuery<MMetricWrapper>)FactoryBusinessOperation.CreateBusinessOperationObject("RetrieveMetric");
        }

        protected override Dictionary<string, BaseModel> LoadContents()
        {
            var map = new Dictionary<string, BaseModel>();
            IEnumerable<MMetricWrapper> metricWrappers = opr.Apply(null, null);

            foreach (var metricWrapper in metricWrappers)
            {
                var metric = metricWrapper.Value;
                map[metric.Key] = metric;
            }

            return map;
        }

        public void SetOperation(IBusinessOperationQuery<MMetricWrapper> opr)
        {
            this.opr = opr; 
        }
    }
}