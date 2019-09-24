using System;
using NUnit.Framework;
using Moq;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Core.NoSQL;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;
using Its.Onix.Erp.Businesses.Mocks;

namespace Its.Onix.Erp.Businesses.Products
{
	public class GetProductInfoTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase("")]
        public void GetProductWithEmptyTest(string code)
        {
            INoSqlContext ctx = new Mock<INoSqlContext>().Object;
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationGetInfo<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("GetProductInfo");
            
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
        public void GetProductNotFoundTest()
        {
            MProduct prdReturned = null;
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            ctx.SetReturnObjectByKey(prdReturned);

            FactoryBusinessOperation.SetNoSqlContext(ctx);
            var opt = (IBusinessOperationGetInfo<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("GetProductInfo");
            
            MProduct pd = new MProduct();
            pd.Code = "MockedCode";
            pd.Key = "FAKED_NOTFOUNDKEY";

            var result = opt.Apply(pd);
            Assert.AreEqual(null, result, "Product not found should return null!!!");
        } 

        [TestCase("CODEFOUND001")]
        [TestCase("CODEFOUND002")]
        public void GetProductFoundTest(string code)
        {
            MProduct prdReturned = new MProduct();
            prdReturned.Code = code;

            MockedNoSqlContext ctx = new MockedNoSqlContext();
            ctx.SetReturnObjectByKey(prdReturned);

            FactoryBusinessOperation.SetNoSqlContext(ctx);
            var opt = (IBusinessOperationGetInfo<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("GetProductInfo");
            
            MProduct pd = new MProduct();
            pd.Code = "MockedCode";
            pd.Key = "FAKED_NOTFOUNDKEY";

            var result = opt.Apply(pd);
            Assert.AreEqual(code, result.Code, "Return product code should be [{0}]!!!", code);
        }               
    }
}
