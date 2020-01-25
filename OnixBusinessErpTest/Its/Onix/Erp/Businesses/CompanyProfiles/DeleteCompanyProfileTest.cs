using System;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
	public class DeleteCompanyProfileTest : OperationTestBase
	{        
        private TestOperationParam param = null;

        public DeleteCompanyProfileTest() : base()
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
        public void DeleteCompanyProfileOperationFoundTest(string db, string provider)
        {            
            bool isOK = DeleteOperationWithExisting<CompanyProfile>(db, provider, param);
            Assert.AreEqual(true, isOK, "Should not be able to delete because existing record is found!!!");
        }

        [TestCase("onix_erp", "sqlite_inmem")]
        //[TestCase("onix_erp", "pgsql")]
        public void DeleteCompanyProfileNotFoundTest(string db, string provider)
        {            
            bool isOK = DeleteOperationWithNotExist<CompanyProfile>(db, provider, param);
            Assert.AreEqual(true, isOK, "Should not be able to delete because primary key [{0}] value not found!!!", param.PkFieldName);
        }       
    }
}
