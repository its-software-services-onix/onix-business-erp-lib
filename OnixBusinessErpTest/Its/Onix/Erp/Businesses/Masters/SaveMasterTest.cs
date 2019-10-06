using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
	public class SaveMasterTest : OperationTestBase
	{
        private TestOperationParam param = null;

        public SaveMasterTest() : base()
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
        [TestCase("onix_erp", "pgsql")]
        public void CreateMasterOperationWithNoDuplicateTest(string db, string provider)
        {
            bool isOk = CreateOperation<Master>(db, provider, false, param);
            Assert.AreEqual(true, isOk, "Object should be able to create!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem")]
        [TestCase("onix_erp", "pgsql")]
        public void CreateMasterOperationWithDuplicateTest(string db, string provider)
        {
            bool isOk = CreateOperation<Master>(db, provider, true, param);
            Assert.AreEqual(true, isOk, "Object should not be able to create!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem")]
        [TestCase("onix_erp", "pgsql")]
        public void UpdateMasterOperationWithNotFoundIdTest(string db, string provider)
        {
            bool isOk = UpdateNotFoundOperation<Master>(db, provider, param);
            Assert.AreEqual(true, isOk, "Object should not be able to update because no ID found!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem")]
        [TestCase("onix_erp", "pgsql")]
        public void UpdateMasterOperationWithDuplicateTest(string db, string provider)
        {
            bool isOk = UpdateOperation<Master>(db, provider, true, param);
            Assert.AreEqual(true, isOk, "Object should not be able to update because unique key constraint!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem")]
        [TestCase("onix_erp", "pgsql")]
        public void UpdateMasterOperationWithoutDuplicateTest(string db, string provider)
        {
            bool isOk = UpdateOperation<Master>(db, provider, false, param);
            Assert.AreEqual(true, isOk, "Object should be able to update because not brak a unique key constraint!!!");
        }                  
    }
}
