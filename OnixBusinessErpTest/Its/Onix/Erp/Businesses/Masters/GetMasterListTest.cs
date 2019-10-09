using System;
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
        }

        [TestCase("onix_erp", "sqlite_inmem")]        
        [TestCase("onix_erp", "pgsql")]
        public void GetListOperationWithNoParameterTest(string db, string provider)
        {
            bool checkOk = GetListOperationWithNoParameter<Master>(db, provider, param);
            Assert.AreEqual(true, checkOk, "Unexpected return value from GetMasterList()!!!");
        }  
    }
}
