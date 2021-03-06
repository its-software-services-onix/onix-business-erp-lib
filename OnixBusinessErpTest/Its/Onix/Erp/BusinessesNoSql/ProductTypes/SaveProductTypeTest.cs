using System;
using NUnit.Framework;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Businesses.Mocks;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.ProductTypes
{
	public class SaveProductTypeTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase("")]
        public void SaveProductTypeWithEmptyTest(string code)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationGetInfo<MProductType>) FactoryBusinessOperation.CreateBusinessOperationObject("SaveProductType");
            
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

        [TestCase("CODEFOUND001")]
        [TestCase("CODEFOUND002")]
        public void SaveProductTypeByUpdatingTheExistingOneTest(string code)
        {
            MProductType prdReturned = new MProductType();
            prdReturned.Code = code;

            MockedNoSqlContext ctx = new MockedNoSqlContext();
            ctx.SetReturnObjectByKey(prdReturned);

            FactoryBusinessOperation.SetNoSqlContext(ctx);
            var opt = (IBusinessOperationGetInfo<MProductType>) FactoryBusinessOperation.CreateBusinessOperationObject("SaveProductType");
            
            MProductType pd = new MProductType();
            pd.Code = "MockedCode";

            var result = opt.Apply(pd);
            Assert.AreEqual(code, result.Code, "Return product type code should be [{0}]!!!", code);            
        } 

        [TestCase]
        public void SaveProductTypeByAddingTheNewOneTest()
        {
            MProductType prdReturned = null;

            MockedNoSqlContext ctx = new MockedNoSqlContext();
            ctx.SetReturnObjectByKey(prdReturned);            

            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationGetInfo<MProductType>) FactoryBusinessOperation.CreateBusinessOperationObject("SaveProductType");
            
            MProductType pd = new MProductType();
            pd.Code = "MockedCode";

            var result = opt.Apply(pd);
            Assert.AreEqual(null, result, "Expected null to return !!!");            
        }         
    }
}
