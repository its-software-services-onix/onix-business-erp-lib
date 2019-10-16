using System;
using NUnit.Framework;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;
using Its.Onix.Erp.Businesses.Mocks;

namespace Its.Onix.Erp.Businesses.Metrices
{
	public class IncreaseAndRetrieveTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [Test]
        public void NewEntry()
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationManipulate<MMetric>) FactoryBusinessOperation.CreateBusinessOperationObject("IncreaseAndRetrieveMetric");
            
            MMetric dat = new MMetric();
            dat.Key = "PageViews";
            dat.Value = 5;

            try
            {
                int result = opt.Apply(dat);
                Assert.AreEqual(5,result);               
            }
            catch (Exception)
            {
                Assert.Fail("Exception should not be thrown here!!!");
            }
        }

        [Test]
        public void UpdateExisting()
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);
            MMetric existing = new MMetric();
            existing.Key = "PageViews";
            existing.Value = 5;
            ctx.SetReturnObjectByKey<MMetric>(existing);

            var opt = (IBusinessOperationManipulate<MMetric>) FactoryBusinessOperation.CreateBusinessOperationObject("IncreaseAndRetrieveMetric");
            
            MMetric dat = new MMetric();
            dat.Key = "PageViews";
            dat.Value = 5;

            try
            {
                int result = opt.Apply(dat);
                Assert.AreEqual(10,result);               
            }
            catch (Exception)
            {
                Assert.Fail("Exception should not be thrown here!!!");
            }
        }        
    }
}
