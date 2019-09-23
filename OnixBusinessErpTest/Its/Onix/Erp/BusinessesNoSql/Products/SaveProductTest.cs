using System;
using NUnit.Framework;

using Moq;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Core.Storages;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;
using Its.Onix.Erp.Businesses.Mocks;

namespace Its.Onix.Erp.Businesses.Products
{
	public class SaveProductTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase("")]
        public void SaveProductWithEmptyTest(string code)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            IStorageContext storageCtx = new Mock<IStorageContext>().Object;
            FactoryBusinessOperation.SetNoSqlContext(ctx);
            FactoryBusinessOperation.SetStorageContext(storageCtx);

            var opt = (IBusinessOperationGetInfo<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("SaveProduct");
            
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

        [TestCase("CODEFOUND001")]
        [TestCase("CODEFOUND002")]
        public void SaveProductByUpdatingTheExistingOneTest(string code)
        {
            MProduct prdReturned = new MProduct();
            prdReturned.Code = code;

            IStorageContext storageCtx = new Mock<IStorageContext>().Object;
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            ctx.SetReturnObjectByKey(prdReturned);

            FactoryBusinessOperation.SetNoSqlContext(ctx);
            FactoryBusinessOperation.SetStorageContext(storageCtx);
            var opt = (IBusinessOperationGetInfo<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("SaveProduct");
            
            MProduct pd = new MProduct();
            pd.Code = "MockedCode";
            pd.Key = "FAKED_NOTFOUNDKEY";

            var result = opt.Apply(pd);
            Assert.AreEqual(code, result.Code, "Return product code should be [{0}]!!!", code);            
        } 

        [TestCase]
        public void SaveProductByAddingTheNewOneTest()
        {
            MProduct prdReturned = null;

            IStorageContext storageCtx = new Mock<IStorageContext>().Object;
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            ctx.SetReturnObjectByKey(prdReturned);            

            FactoryBusinessOperation.SetNoSqlContext(ctx);
            FactoryBusinessOperation.SetStorageContext(storageCtx);

            var opt = (IBusinessOperationGetInfo<MProduct>) FactoryBusinessOperation.CreateBusinessOperationObject("SaveProduct");
            
            MProduct pd = new MProduct();
            pd.Code = "MockedCode";
            pd.Key = "FAKED_NOTFOUNDKEY";

            var result = opt.Apply(pd);
            Assert.AreEqual(null, result, "Expected null to return !!!");            
        }         
    }
}
