using System.Collections;
using NUnit.Framework;

using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
	public class GetMasterListTest : OperationTestBase
	{        
        private TestOperationParam param = null;

        public GetMasterListTest() : base()
        {
        }

        [SetUp]
        public void Setup()
        {
            param = new TestOperationParam();
            param.GetListName = "GetMasterList";
            param.SaveOprName = "SaveMaster";
            param.PkFieldName = "MasterId";
            param.KeyFieldName = "Code";
        }

        [TestCase("onix_erp", "sqlite_inmem")]        
        //[TestCase("onix_erp", "pgsql")]
        public void GetListOperationWithNoParameterTest(string db, string provider)
        {
            bool checkOk = GetListOperationWithNoParameter<Master>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetMasterList()!!!");
        }  

        [TestCase("onix_erp", "sqlite_inmem")]        
        public void GetListOperationWithParameter(string db, string provider)
        {
            CreateOnixDbContext(db, provider);

            QueryRequestParam qrp = new QueryRequestParam();

            qrp.AddFilter("Code", "EQUAL", "N0");
            qrp.AddFilter("Name", "CONTAIN", "ABC");
            qrp.AddFilter("MasterId", "=", "1000");
            qrp.AddFilter("MasterId", "IS_NULL", "N");
            qrp.AddFilter("Key", "IS_NULL", "Y");

            qrp.AddOrderBy("Type", "DESC");
            qrp.AddOrderBy("Code", "ASC");
            QueryResponseParam response = GetListOperationWithParameter<Master>(db, provider, param, qrp);
            
            //Assert.AreEqual(true, checkOk, "Unexpected return value from GetMasterList()!!!");
        }     

        [TestCase("onix_erp", "sqlite_inmem")]        
        public void GetListOperationNoErrorWithNegativeInputTest(string db, string provider)
        {
            CreateOnixDbContext(db, provider);
            ArrayList arr = CreateMultipleItems<Master>(db, provider, param, 100, "TESTING");

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
                QueryResponseParam response = GetListOperationWithParameter<Master>(db, provider, param, qrp);
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
            ArrayList arr = CreateMultipleItems<Master>(db, provider, param, count, "TESTING");

            QueryRequestParam qrp = new QueryRequestParam();
            QueryResponseParam response = GetListOperationWithParameter<Master>(db, provider, param, qrp);
            Assert.AreEqual(count, response.Results.Count, "Item count should return as expected!!!");
        }                            
    }
}
