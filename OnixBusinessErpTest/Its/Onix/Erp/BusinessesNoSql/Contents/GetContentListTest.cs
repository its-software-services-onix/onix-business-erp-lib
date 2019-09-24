using System;
using NUnit.Framework;
using Moq;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Core.NoSQL;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.Contents
{
	public class GetContentListTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase("")]
        public void GenericGetProductListTest(string code)
        {
            INoSqlContext ctx = new Mock<INoSqlContext>().Object;
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationQuery<MContent>) FactoryBusinessOperation.CreateBusinessOperationObject("GetContentList");
            
            try
            {
                opt.Apply(null, null);                
            }
            catch (Exception)
            {
                Assert.Fail("Exception should not be thrown here!!!");
            }
        }        
    }
}
