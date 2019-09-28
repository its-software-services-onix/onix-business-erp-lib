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
        //[TestCase("onix_erp", "pgsql", "MasterId")]
        public void SaveCreateMasterOperationTest(string db, string provider, string pk)
        {
            bool isOK = IsSaveCreateOperationOk<Master>(db, provider, "SaveMaster", "DeleteMaster", pk);
            Assert.AreEqual(true, isOK, "Primary key ID [{0}] must be returned!!!", pk);
        } 

        [TestCase("onix_erp", "sqlite_inmem", "MasterId", "Code")]
        //[TestCase("onix_erp", "pgsql", "MasterId", "Code")]
        public void SaveDuplicateUniqueKeyTest(string db, string provider, string pk, string fieldName)
        {
            bool isOK2 = IsDuplicateUniqueKeyOk<Master>(db, provider, "SaveMaster", pk, fieldName);
            Assert.AreEqual(true, isOK2, "[{0}] should not allow to duplicate!!!", fieldName);
        }       

        [TestCase("onix_erp", "sqlite_inmem", "MasterId", "Code")]
        //[TestCase("onix_erp", "pgsql", "MasterId", "Code")]
        public void SaveUsingContextTest(string db, string provider, string pk, string fieldName)
        {
            CreateOnixDbContext(db, provider);

            bool isOK0 = IsCreateDuplicateUniqueCheckOk<Master>(db, provider, "SaveMaster", pk, fieldName);
            Assert.AreEqual(true, isOK0, "[{0}] should not allow to duplicate!!!", fieldName);

            bool isOK1 = IsCreateDuplicateUniqueKeyDifferentCheckOk<Master>(db, provider, "SaveMaster", pk);
            Assert.AreEqual(true, isOK1, "[{0}] should not allow to duplicate!!!", fieldName);
            
            bool isOK2 = IsSaveCreateOperationOk<Master>(db, provider, "SaveMaster", "DeleteMaster", pk);
            Assert.AreEqual(true, isOK2, "[{0}] should not allow to duplicate!!!", fieldName);
        }      

        [TestCase("onix_erp", "sqlite_inmem", "MasterId")]
        //[TestCase("onix_erp", "pgsql", "MasterId")]
        public void SaveUpdateMasterOperationTest(string db, string provider, string pk)
        {
            bool isOK = IsSaveUpdateOperationOk<Master>(db, provider, "SaveMaster", "DeleteMaster", pk);
            Assert.AreEqual(true, isOK, "Primary key ID [{0}] must be returned!!!", pk);
        }                    
    }
}
