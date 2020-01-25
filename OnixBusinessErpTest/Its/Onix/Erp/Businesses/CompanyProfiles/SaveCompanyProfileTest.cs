using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
	public class SaveCompanyProfileTest : OperationTestBase
	{
        private TestOperationParam param = null;

        public SaveCompanyProfileTest() : base()
        {          
        }

        [SetUp]
        public void Setup()
        {
            param = new TestOperationParam();
            param.DeleteOprName = "DeleteCompanyProfile";
            param.SaveOprName = "SaveCompanyProfile";
            param.KeyFieldName = "Code";
            param.PkFieldName = "CompanyProfileId";                            
        }

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void CreateCompanyProfileOperationWithNoDuplicateTest(string db, string provider)
        {
            bool isOk = CreateOperation<CompanyProfile>(db, provider, false, param);
            Assert.AreEqual(true, isOk, "Object should be able to create!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void CreateCompanyProfileOperationWithDuplicateTest(string db, string provider)
        {
            bool isOk = CreateOperation<CompanyProfile>(db, provider, true, param);
            Assert.AreEqual(true, isOk, "Object should not be able to create!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void UpdateCompanyProfileOperationWithNotFoundIdTest(string db, string provider)
        {
            bool isOk = UpdateNotFoundOperation<CompanyProfile>(db, provider, param);
            Assert.AreEqual(true, isOk, "Object should not be able to update because no ID found!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void UpdateCompanyProfileOperationWithDuplicateTest(string db, string provider)
        {
            bool isOk = UpdateOperation<CompanyProfile>(db, provider, true, param);
            Assert.AreEqual(true, isOk, "Object should not be able to update because unique key constraint!!!");
        } 

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void UpdateCompanyProfileOperationWithoutDuplicateTest(string db, string provider)
        {
            bool isOk = UpdateOperation<CompanyProfile>(db, provider, false, param);
            Assert.AreEqual(true, isOk, "Object should be able to update because not brak a unique key constraint!!!");
        }                  
    }
}
