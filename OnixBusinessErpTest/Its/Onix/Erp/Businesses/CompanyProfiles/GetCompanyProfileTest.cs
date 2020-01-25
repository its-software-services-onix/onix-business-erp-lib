using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
	public class GetCompanyProfileTest : OperationTestBase
	{        
        private TestOperationParam param = null;

        public GetCompanyProfileTest() : base()
        {
        }

        [SetUp]
        public void Setup()
        {
            param = new TestOperationParam();
            param.DeleteOprName = "DeleteCompanyProfile";
            param.SaveOprName = "SaveCompanyProfile";
            param.GetInfoName = "GetCompanyProfileInfo";
            param.PkFieldName = "CompanyProfileId";
        }

        [TestCase("onix_erp", "sqlite_inmem")]        
        //[TestCase("onix_erp", "pgsql")]
        public void CheckIfInvalidCompanyProfileIdTest(string db, string provider)
        {
            bool checkOk = GetInfoOperationWithInvalidId<CompanyProfile>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetCompanyProfileInfo()!!!");
        }  

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void CheckIfCompanyProfileIdExistTest(string db, string provider)
        {
            bool checkOk = GetInfoOperationWithExisting<CompanyProfile>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetCompanyProfileInfo()!!!");
        }

        [TestCase("onix_erp", "sqlite_inmem")]        
        //[TestCase("onix_erp", "pgsql")]
        public void NullReturnIfMasterNotFoundTest(string db, string provider)
        {
            bool checkOk = GetInfoNullIfNotFound<CompanyProfile>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetCompanyProfileinfo()!!!");
        }                                               
    }
}
