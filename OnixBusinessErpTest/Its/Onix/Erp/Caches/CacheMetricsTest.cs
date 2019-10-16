using NUnit.Framework;
using Moq;
using System.Collections.Generic;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Caches;

namespace Magnum.Web.Utils
{
    public class CacheMetricsTest
    {
        private  Mock<CacheMetrics> mockCache;
        private  CacheMetrics cache;

        private  CacheMetrics realCache;

        private Mock<IBusinessOperationQuery<MMetricWrapper>> mockOpr;

        public CacheMetricsTest()
        {            
            Its.Onix.Erp.Utils.FactoryCacheUtils.LoadBusinessOperations();
        }

        [SetUp]
        public void Setup()
        {

            IEnumerable<MMetricWrapper> dummy = getDummyMetricWrapper();
            mockOpr = new Mock<IBusinessOperationQuery<MMetricWrapper>>();
            mockOpr.Setup(foo => foo.Apply(null, null)).Returns(dummy);
            mockCache = new Mock<CacheMetrics>() { CallBase = true };
            cache = mockCache.Object;
            cache.SetOperation(mockOpr.Object);
            realCache = new CacheMetrics();
        }


        [Test]
        public void LoadContents()
        {
            var metrics = cache.GetValues();

            Assert.AreEqual(50, ((MMetric)metrics["PageViews"]).Value);
            Assert.AreEqual(100, ((MMetric)metrics["TotalProducts"]).Value);
            Assert.AreEqual(2, metrics.Count);
        }

        private IEnumerable<MMetricWrapper> getDummyMetricWrapper()
        {
            var metric1 = new MMetric();
            metric1.Key = "PageViews";
            metric1.Value = 50;

            var metric2 = new MMetric();
            metric2.Key = "TotalProducts";
            metric2.Value = 100;

            var metricWrapper1 = new MMetricWrapper();
            metricWrapper1.Value = metric1;

            var metricWrapper2 = new MMetricWrapper();
            metricWrapper2.Value = metric2;

            var list = new List<MMetricWrapper>();
            list.Add(metricWrapper1);
            list.Add(metricWrapper2);
            IEnumerable<MMetricWrapper> dummy = (IEnumerable<MMetricWrapper>)list;
            return dummy;
        }
    }
}