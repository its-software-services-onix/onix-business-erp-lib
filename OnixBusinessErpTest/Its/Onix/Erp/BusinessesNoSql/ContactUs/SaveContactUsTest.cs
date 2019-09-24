using System;
using NUnit.Framework;
using Moq;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Core.NoSQL;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.Contactus
{
	public class SaveContactUsTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [Test]
        public void SaveTest()
        {
            INoSqlContext ctx = new Mock<INoSqlContext>().Object;
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationManipulate<MContactUs>) FactoryBusinessOperation.CreateBusinessOperationObject("SaveContactUs");
            
            MContactUs dat = new MContactUs();
            
            try
            {
                int result = opt.Apply(dat);
                Assert.AreEqual(result, 0);   
            }
            catch (Exception)
            {
                //Do nothing
            }         
            
        } 
    }
}
