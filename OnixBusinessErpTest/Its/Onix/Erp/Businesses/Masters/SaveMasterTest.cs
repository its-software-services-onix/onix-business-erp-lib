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

        [TestCase("onix_erp", "sqlite_inmem", "MasterId")]
        [TestCase("onix_erp", "pgsql", "MasterId")]
        public void SaveMasterOperationTest(string db, string provider, string pk)
        {
            bool isOK = IsSaveOperationOk<Master>(db, provider, "SaveMaster", "DeleteMaster", pk);
            Assert.AreEqual(true, isOK, "Primary key ID [{0}] must be returned!!!", pk);
        } 

        [TestCase("onix_erp", "sqlite_inmem", "MasterId", "Code")]
        [TestCase("onix_erp", "pgsql", "MasterId", "Code")]
        public void SaveDuplicateUniqueKeyTest(string db, string provider, string pk, string fieldName)
        {
            bool isOK2 = IsDuplicateUniqueKeyOk<Master>(db, provider, "SaveMaster", pk, fieldName);
            Assert.AreEqual(true, isOK2, "[{0}] should not allow to duplicate!!!", fieldName);
        }         
    }
}
