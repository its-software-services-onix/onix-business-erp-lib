using System;
using NUnit.Framework;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Businesses.Mocks;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.ProductTypes
{
	public class GetProductTypeListTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }


        [TestCase("")]
        public void GenericGetProductTypeListTest(string code)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationQuery<MProductType>) FactoryBusinessOperation.CreateBusinessOperationObject("GetProductTypeList");
            
            MProductType pd = new MProductType();
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
