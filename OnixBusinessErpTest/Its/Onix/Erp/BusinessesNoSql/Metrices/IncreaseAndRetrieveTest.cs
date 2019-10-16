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
        public void Apply()
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationManipulate<MMetric>) FactoryBusinessOperation.CreateBusinessOperationObject("IncreaseAndRetrieveMetric");
            
            MMetric dat = new MMetric();
            dat.Key = "PageViews";
            dat.Value = 5;

            try
            {
                opt.Apply(dat);                
            }
            catch (Exception)
            {
                Assert.Fail("Exception should not be thrown here!!!");
            }
        }        
    }
}
