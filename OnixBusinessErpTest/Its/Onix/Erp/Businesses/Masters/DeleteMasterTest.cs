using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
	public class DeleteMasterTest : OperationTestBase
	{
        public DeleteMasterTest() : base()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [TestCase("onix_erp", "pgsql")]
        public void DeleteMasterOperationFoundTest(string db, string provider)
        {
            CreateOnixDbContext(db, provider);
            var opr = CreateManipulateOperation("SaveMaster");
            var del = CreateManipulateOperation("DeleteMaster");
            
            Master m = new Master() { Code = "01", Name = "Will be deleted later" };
            Master o = (Master) opr.Apply(m);

            del.Apply(o);
            
            //No excption a this point
            Assert.True(true);
        } 

        [TestCase("onix_erp", "pgsql")]
        public void DeleteMasterOperationNotFoundTest(string db, string provider)
        {            
            CreateOnixDbContext(db, provider);
            var opr = CreateManipulateOperation("DeleteMaster");
            
            Master m = new Master() { MasterId = 999999999 };

            try
            {
                opr.Apply(m);
                Assert.Fail("Exceptin should be thrown here!!!");
            }
            catch
            {
                Assert.True(true);
            }
        } 
    }
}
