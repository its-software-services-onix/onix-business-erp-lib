using System;
using NUnit.Framework;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Businesses.Mocks;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.ProductTypes
{
	public class GetProductTypeInfoTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase("")]
        public void GetProductTypeWithEmptyTest(string code)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationGetInfo<MProductType>) FactoryBusinessOperation.CreateBusinessOperationObject("GetProductTypeInfo");
            
            MProductType pd = new MProductType();
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
        public void GetProductTypeNotFoundTest()
        {
            MProductType prdReturned = null;
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            ctx.SetReturnObjectByKey(prdReturned);

            FactoryBusinessOperation.SetNoSqlContext(ctx);
            var opt = (IBusinessOperationGetInfo<MProductType>) FactoryBusinessOperation.CreateBusinessOperationObject("GetProductTypeInfo");
            
            MProductType pd = new MProductType();
            pd.Code = "MockedCode";

            var result = opt.Apply(pd);
            Assert.AreEqual(null, result, "Product type not found should return null!!!");
        } 

        [TestCase("CODEFOUND001")]
        [TestCase("CODEFOUND002")]
        public void GetProductTypeFoundTest(string code)
        {
            MProductType prdReturned = new MProductType();
            prdReturned.Code = code;

            MockedNoSqlContext ctx = new MockedNoSqlContext();
            ctx.SetReturnObjectByKey(prdReturned);

            FactoryBusinessOperation.SetNoSqlContext(ctx);
            var opt = (IBusinessOperationGetInfo<MProductType>) FactoryBusinessOperation.CreateBusinessOperationObject("GetProductTypeInfo");
            
            MProductType pd = new MProductType();
            pd.Code = "MockedCode";

            var result = opt.Apply(pd);
            Assert.AreEqual(code, result.Code, "Return product type code should be [{0}]!!!", code);
        }               
    }
}
