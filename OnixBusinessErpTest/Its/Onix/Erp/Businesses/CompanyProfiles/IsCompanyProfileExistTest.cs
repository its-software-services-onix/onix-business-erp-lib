using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
	public class IsCompanyProfileExistTest : OperationTestBase
	{        
        private TestOperationParam param = null;

        public IsCompanyProfileExistTest() : base()
        {
        }

        [SetUp]
        public void Setup()
        {
            param = new TestOperationParam();
            param.DeleteOprName = "DeleteCompanyProfile";
            param.SaveOprName = "SaveCompanyProfile";
            param.IsExistOprName = "IsCompanyProfileExist";
            param.KeyFieldName = "Code";
            param.PkFieldName = "CompanyProfileId";
        }

        [TestCase("onix_erp", "sqlite_inmem", true, "add")]        
        [TestCase("onix_erp", "sqlite_inmem", true, "add")]
        //[TestCase("onix_erp", "pgsql", true, "add")]
        //[TestCase("onix_erp", "pgsql", true, "add")]
        public void CheckExistIfKeyFoundAnotherAddTest(string db, string provider, bool foundEarlier, string mode)
        {
            param.CreateDummyRecord = foundEarlier;
            param.Mode = mode;

            bool isExist = IsExistFromOperation<CompanyProfile>(db, provider, param);
            Assert.AreEqual(true, isExist, "Unexpected return value from IsCompanyProfileExist()!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem", false, "add")]        
        [TestCase("onix_erp", "sqlite_inmem", false, "add")]
        //[TestCase("onix_erp", "pgsql", false, "add")]
        //[TestCase("onix_erp", "pgsql", false, "add")]
        public void CheckExistIfKeyNotFoundAnotherAddTest(string db, string provider, bool foundEarlier, string mode)
        {
            param.CreateDummyRecord = foundEarlier;
            param.Mode = mode;

            bool isExist = IsExistFromOperation<CompanyProfile>(db, provider, param);
            Assert.AreEqual(false, isExist, "Unexpected return value from IsCompanyProfileExist()!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem", true, "edit", true)]        
        [TestCase("onix_erp", "sqlite_inmem", true, "edit", false)]
        //[TestCase("onix_erp", "pgsql", true, "edit", true)]
        //[TestCase("onix_erp", "pgsql", true, "edit", false)]
        public void CheckExistIfKeyFoundAnotherEditTest(string db, string provider, bool foundEarlier, string mode, bool selfCheck)
        {
            param.CreateDummyRecord = foundEarlier;
            param.Mode = mode;
            param.IsExistSelfIdCheck = selfCheck;

            bool isExist = IsExistFromOperation<CompanyProfile>(db, provider, param);
            bool isNotExist = selfCheck;
            Assert.AreEqual(!isNotExist, isExist, "Unexpected return value from IsCompanyProfileExist()!!!");
        }                                    
    }
}
