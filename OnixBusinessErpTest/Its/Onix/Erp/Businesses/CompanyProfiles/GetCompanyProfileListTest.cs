using System.Collections;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
	public class GetCompanyProfileListTest : OperationTestBase
	{        
        private TestOperationParam param = null;

        public GetCompanyProfileListTest() : base()
        {
        }

        [SetUp]
        public void Setup()
        {
            param = new TestOperationParam();
            param.GetListName = "GetCompanyProfileList";
            param.SaveOprName = "SaveCompanyProfile";
            param.PkFieldName = "CompanyProfileId";
            param.KeyFieldName = "Code";
        }

        [TestCase("onix_erp", "sqlite_inmem")]        
        //[TestCase("onix_erp", "pgsql")]
        public void GetListOperationWithNoParameterTest(string db, string provider)
        {
            bool checkOk = GetListOperationWithNoParameter<CompanyProfile>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetCompanyProfileList()!!!");
        }  

        [TestCase("onix_erp", "sqlite_inmem")]        
        public void GetListOperationWithParameter(string db, string provider)
        {
            CreateOnixDbContext(db, provider);

            QueryRequestParam qrp = new QueryRequestParam();

            qrp.AddFilter("Code", "EQUAL", "N0");
            qrp.AddFilter("Name", "CONTAIN", "ABC");
            qrp.AddFilter("CompanyProfileId", "=", "1000");
            qrp.AddFilter("CompanyProfileId", "IS_NULL", "N");
            qrp.AddFilter("Key", "IS_NULL", "Y");

            qrp.AddOrderBy("Type", "DESC");
            qrp.AddOrderBy("Code", "ASC");
            QueryResponseParam response = GetListOperationWithParameter<CompanyProfile>(db, provider, param, qrp);
            
            //Assert.AreEqual(true, checkOk, "Unexpected return value from GetCompanyProfileList()!!!");
        }     

        [TestCase("onix_erp", "sqlite_inmem")]        
        public void GetListOperationNoErrorWithNegativeInputTest(string db, string provider)
        {
            CreateOnixDbContext(db, provider);
            ArrayList arr = CreateMultipleItems<CompanyProfile>(db, provider, param, 100, "TESTING");

            QueryRequestParam qrp = new QueryRequestParam();

            qrp.ByChunk = true;
            qrp.PageSize = 9000;
            
            qrp.AddFilter("Code", "RUNKNOWN_OPERATOR", "N0");
            qrp.AddFilter("UnknownField", "CONTAIN", "ABC");

            qrp.AddOrderBy("UnknownField", "DESC");
            qrp.AddOrderBy("Code", "DESC");
            qrp.AddOrderBy("Name", "DESC");

            try
            {
                QueryResponseParam response = GetListOperationWithParameter<CompanyProfile>(db, provider, param, qrp);
            }
            catch
            {                
                Assert.Fail("Exception should not thrown here!!!");
            }
        } 


        [TestCase("onix_erp", "sqlite_inmem", 100)]        
        public void GetListOperationAllItemsTest(string db, string provider, int count)
        {
            CreateOnixDbContext(db, provider);
            ArrayList arr = CreateMultipleItems<CompanyProfile>(db, provider, param, count, "TESTING");

            QueryRequestParam qrp = new QueryRequestParam();
            QueryResponseParam response = GetListOperationWithParameter<CompanyProfile>(db, provider, param, qrp);
            Assert.AreEqual(count, response.Results.Count, "Item count should return as expected!!!");
        }                            
    }
}
