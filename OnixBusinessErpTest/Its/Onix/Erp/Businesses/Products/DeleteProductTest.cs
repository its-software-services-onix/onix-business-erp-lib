using System;
using NUnit.Framework;
using Moq;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Businesses.Mocks;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.Products
{
	public class DeleteProductTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase("")]
        public void DeleteProductWithEmptyTest(string code)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationManipulate<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("DeleteProduct");
            
            MProduct pd = new MProduct();
            pd.Code = code;
            
            try
            {
                opt.Apply(pd);
                Assert.Fail("Exception should be thrown");
            }
            catch (Exception)
            {
                //Do nothing
            }
        } 

        [TestCase]
        public void DeleteProductAnyCaseTest()
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();

            FactoryBusinessOperation.SetNoSqlContext(ctx);
            var opt = (IBusinessOperationManipulate<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("DeleteProduct");
            
            MProduct pd = new MProduct();
            pd.Code = "MockedCode";
            pd.Key = "FAKED_NOTFOUNDKEY";

            var result = opt.Apply(pd);
            Assert.AreEqual(1, result, "Row affected should be returned !!!");
        }           
    }
}
