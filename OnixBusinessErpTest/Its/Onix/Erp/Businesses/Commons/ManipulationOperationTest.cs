using System;
using System.Reflection;
using NUnit.Framework;

using Its.Onix.Core.Factories;

namespace Its.Onix.Erp.Businesses.Commons
{
	public class ManipulationOperationTest : OperationTestBase
	{        
        public ManipulationOperationTest() : base()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("onix_erp", "sqlite_inmem")]
        public void GenericExceptionTest(string db, string provider)        
        {            
            Assembly asm = Assembly.GetExecutingAssembly();

            CreateOnixDbContext(db, provider);
            FactoryBusinessOperation.RegisterBusinessOperation(asm, "OperationMocked", "Its.Onix.Erp.Businesses.Commons.OperationMocked");

            var opr = CreateManipulateOperation("OperationMocked");
            try
            {
                opr.Apply(null);
                Assert.Fail("InvalidOperationException should be thrown here!!!");
            }
            catch (InvalidOperationException)
            {
                Assert.Pass();
            }
        }
    }
}
