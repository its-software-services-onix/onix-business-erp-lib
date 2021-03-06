using NUnit.Framework;
using Moq;
using System.Collections.Generic;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Caches;

namespace Magnum.Web.Utils
{
    public class CacheProductsTypeListTest
    {
        private Mock<CacheProductTypeList> mockCache;
        private Mock<IBusinessOperationQuery<MProductType>> mockOpr;
        private CacheProductTypeList cache;
        private CacheProductTypeList realCache;
        
        public CacheProductsTypeListTest()
        {            
            Its.Onix.Erp.Utils.FactoryCacheUtils.LoadBusinessOperations();
        }

        [SetUp]
        public void Setup()
        {
            IEnumerable<MProductType> dummy = getDummyContents();
            mockOpr = new Mock<IBusinessOperationQuery<MProductType>>();
            mockOpr.Setup(foo => foo.Apply(null, null)).Returns(dummy);
            mockCache = new Mock<CacheProductTypeList>() { CallBase = true };
            cache = mockCache.Object;
            cache.SetOperation(mockOpr.Object);
            realCache = new CacheProductTypeList();
        }

        [Test]
        public void LoadContents()
        {
            var products = cache.GetValues();

            Assert.AreEqual("A", ((MProductType)products["001"]).Descriptions["EN"].Name);
            Assert.AreEqual("B", ((MProductType)products["002"]).Descriptions["EN"].Name);
            Assert.AreEqual(2, products.Count);
        }

        private IEnumerable<MProductType> getDummyContents()
        {
            var pro1 = new MProductType();
            pro1.Code = "001";
            pro1.Descriptions["EN"] = new MGenericDescription();
            pro1.Descriptions["EN"].Name = "A";

            var pro2 = new MProductType();
            pro2.Code = "002";
            pro2.Descriptions["EN"] = new MGenericDescription();
            pro2.Descriptions["EN"].Name = "B";

            var list = new List<MProductType>();
            list.Add(pro1);
            list.Add(pro2);
            IEnumerable<MProductType> dummy = (IEnumerable<MProductType>)list;
            return dummy;
        }
    }
}