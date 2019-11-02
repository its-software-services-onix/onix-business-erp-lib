using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
	public class DeleteMasterTest : OperationTestBase
	{        
        private TestOperationParam param = null;

        public DeleteMasterTest() : base()
        {        
        }

        [SetUp]
        public void Setup()
        {
            param = new TestOperationParam();
            param.DeleteOprName = "DeleteMaster";
            param.SaveOprName = "SaveMaster";
            param.KeyFieldName = "Code";
            param.PkFieldName = "MasterId";            
        }

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void DeleteMasterOperationFoundTest(string db, string provider)
        {            
            bool isOK = DeleteOperationWithExisting<Master>(db, provider, param);
            Assert.AreEqual(true, isOK, "Should not be able to delete because existing record is found!!!");
        }

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void DeleteMasterOperationNotFoundTest(string db, string provider)
        {            
            bool isOK = DeleteOperationWithNotExist<Master>(db, provider, param);
            Assert.AreEqual(true, isOK, "Should not be able to delete because primary key [{0}] value not found!!!", param.PkFieldName);
        }       
    }
}
