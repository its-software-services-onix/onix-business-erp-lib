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
	public class SaveContentTest
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

            var opt = (IBusinessOperationManipulate<MContent>)FactoryBusinessOperation.CreateBusinessOperationObject("SaveContent");

            MContent dat = new MContent();
            dat.Name = "001";
            dat.Type = "txt";
            dat.Values["EN"] = "one";
            try
            {
                int result = opt.Apply(dat);
                Assert.AreEqual(result, 0);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void SaveBlankObject()
        {
            INoSqlContext ctx = new Mock<INoSqlContext>().Object;
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationManipulate<MContent>)FactoryBusinessOperation.CreateBusinessOperationObject("SaveContent");

            MContent dat = new MContent();

            try
            {
                int result = opt.Apply(dat);
                Assert.Fail();
            }
            catch (Exception)
            {
                //Error should be thrown.
                Assert.Pass();
            }
        }
    }
}
