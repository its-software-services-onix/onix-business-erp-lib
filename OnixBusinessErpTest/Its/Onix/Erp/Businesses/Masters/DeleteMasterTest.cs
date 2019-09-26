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

        [TestCase("onix_erp", "sqlite_inmem", "MasterId")]
        //[TestCase("onix_erp", "pgsql", "MasterId")]
        public void DeleteMasterOperationFoundTest(string db, string provider, string pk)
        {            
            //Delete found test is tested along with the SaveMasterTest.cs
        }

        [TestCase("onix_erp", "sqlite_inmem", "MasterId")]
        //[TestCase("onix_erp", "pgsql", "MasterId")]
        public void DeleteMasterOperationNotFoundTest(string db, string provider, string pk)
        {            
            bool isOK = IsDeleteNotFoundOk<Master>(db, provider, "DeleteMaster", pk);
            Assert.AreEqual(true, isOK, "Should not be able to delete be cause primary key [{0}] value not found!!!", pk);
        } 
    }
}
