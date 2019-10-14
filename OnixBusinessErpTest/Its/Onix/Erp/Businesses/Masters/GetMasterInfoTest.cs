using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
	public class GetMasterInfoTest : OperationTestBase
	{        
        private TestOperationParam param = null;

        public GetMasterInfoTest() : base()
        {
        }

        [SetUp]
        public void Setup()
        {
            param = new TestOperationParam();
            param.DeleteOprName = "DeleteMaster";
            param.SaveOprName = "SaveMaster";
            param.GetInfoName = "GetMasterInfo";
            param.PkFieldName = "MasterId";
        }

        [TestCase("onix_erp", "sqlite_inmem")]        
        //[TestCase("onix_erp", "pgsql")]
        public void CheckIfInvalidMasterIdTest(string db, string provider)
        {
            bool checkOk = GetInfoOperationWithInvalidId<Master>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetMasterinfo()!!!");
        }  

        [TestCase("onix_erp", "sqlite_inmem")]        
        //[TestCase("onix_erp", "pgsql")]
        public void CheckIfMasterIdExistTest(string db, string provider)
        {
            bool checkOk = GetInfoOperationWithExisting<Master>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetMasterinfo()!!!");
        }

        [TestCase("onix_erp", "sqlite_inmem")]        
        //[TestCase("onix_erp", "pgsql")]
        public void NullReturnIfMasterNotFoundTest(string db, string provider)
        {
            bool checkOk = GetInfoNullIfNotFound<Master>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetMasterinfo()!!!");
        }                                               
    }
}
