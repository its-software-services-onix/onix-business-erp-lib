using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
	public class SaveMasterTest : OperationTestBase
	{
        public SaveMasterTest() : base()
        {
        }

        [SetUp]
        public void Setup()
        {            
        }

        [TestCase("onix_erp", "sqlite_inmem")]
        public void SaveMasterOperationTest(string db, string provider)
        {
            CreateOnixDbContext(db, provider);
            var opr = CreateManipulateOperation("SaveMaster");
            var del = CreateManipulateOperation("DeleteMaster");
            
            Master m = new Master() { Code = "01", Name = "Master01" };
            Master o = (Master) opr.Apply(m);

            Assert.AreNotEqual(0, o.MasterId, "Primary key ID must be returned!!!");

            del.Apply(o);

            //No excption a this point
            Assert.True(true);            
        } 
    }
}
