using NUnit.Framework;
using Moq;
using System.Collections.Generic;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Caches;

namespace Magnum.Web.Utils
{
    public class CacheProductListTest
    {
        private  Mock<CacheProductList> mockCache;
        private  Mock<IBusinessOperationQuery<MProduct>> mockOpr;
        private  CacheProductList cache;
        private CacheProductList realCache;

        public CacheProductListTest()
        {            
            Its.Onix.Erp.Utils.FactoryCacheUtils.LoadBusinessOperations();
        }

        [SetUp]
        public void Setup()
        {
            IEnumerable<MProduct> dummy = getDummyContents();
            mockOpr = new Mock<IBusinessOperationQuery<MProduct>>();
            mockOpr.Setup(foo => foo.Apply(null, null)).Returns(dummy);
            mockCache = new Mock<CacheProductList>() { CallBase = true };
            cache = mockCache.Object;
            cache.SetOperation(mockOpr.Object);
            realCache = new CacheProductList();
        }


        [Test]
        public void LoadContents()
        {
            var products = cache.GetValues();

            Assert.AreEqual("A", ((MProduct)products["001"]).ProductType);
            Assert.AreEqual("B", ((MProduct)products["002"]).ProductType);
            Assert.AreEqual(2, products.Count);
        }

        private IEnumerable<MProduct> getDummyContents()
        {
            var pro1 = new MProduct();
            pro1.Code = "001";
            pro1.ProductType = "A";

            var pro2 = new MProduct();
            pro2.Code = "002";
            pro2.ProductType = "B";

            var list = new List<MProduct>();
            list.Add(pro1);
            list.Add(pro2);
            IEnumerable<MProduct> dummy = (IEnumerable<MProduct>)list;
            return dummy;
        }
    }
}