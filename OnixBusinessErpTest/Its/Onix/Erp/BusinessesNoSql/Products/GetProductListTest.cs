using System;
using NUnit.Framework;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;
using Its.Onix.Erp.Businesses.Mocks;

namespace Its.Onix.Erp.Businesses.Products
{
	public class GetProductListTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase("")]
        public void GenericGetProductListTest(string code)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationQuery<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("GetProductList");
            
            MProduct pd = new MProduct();
            pd.Code = code;
            
            try
            {
                opt.Apply(pd, null);                
            }
            catch (Exception)
            {
                Assert.Fail("Exception should not be thrown here!!!");
            }
        }        
    }
}
