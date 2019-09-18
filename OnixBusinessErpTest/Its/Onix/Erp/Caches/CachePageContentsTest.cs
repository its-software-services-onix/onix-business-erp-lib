using System;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Caches;

namespace Magnum.Web.Utils
{
    public class CachePageContentsTest
    {
        private  Mock<CachePageContents> mockCache;
        private  Mock<IBusinessOperationQuery<MContent>> mockOpr;
        private  CachePageContents cache;
        private CachePageContents realCache;

        public CachePageContentsTest()
        {            
            Its.Onix.Erp.Utils.FactoryCacheUtils.LoadBusinessOperations();
        }

        [SetUp]
        public void Setup()
        {
            IEnumerable<MContent> dummy = getDummyContents();
            mockOpr = new Mock<IBusinessOperationQuery<MContent>>();
            mockOpr.Setup(foo => foo.Apply(null, null)).Returns(dummy);
            mockCache = new Mock<CachePageContents>() { CallBase = true };
            cache = mockCache.Object;
            cache.SetOperation(mockOpr.Object);
            realCache = new CachePageContents();
        }

        [Test]
        public void LoadContentsFirstTime()
        {
            var contents = cache.GetValues();

            Assert.AreEqual("one", ((MContent)contents["txt/001"]).Values["EN"]);
            Assert.AreEqual("two", ((MContent)contents["jpg/002"]).Values["EN"]);
            Assert.AreEqual(2, contents.Count);
        }

        [Test]
        public void GetValue()
        {
            var content = (MContent)cache.GetValue("txt/001");
            Assert.AreEqual("one", content.Values["EN"]);
        }

        [Test]
        public void LoadContentsByRefresh()
        {
            cache.SetLastRefreshDtm(DateTime.Now.AddMinutes(-6));
            cache.SetContents(new Dictionary<string, BaseModel>());
            cache.SetRefreshInterval(TimeSpan.TicksPerMinute * 5);
            var contents = cache.GetValues();
            Assert.AreEqual("one", ((MContent)contents["txt/001"]).Values["EN"]);
            Assert.AreEqual("two", ((MContent)contents["jpg/002"]).Values["EN"]);
            Assert.AreEqual(2, contents.Count);
        }

        [Test]
        public void LoadContentsNoRefresh()
        {
            cache.SetLastRefreshDtm(DateTime.Now);
            cache.SetContents(new Dictionary<string, BaseModel>());
            var contents = cache.GetValues();

            Assert.AreEqual(0, contents.Count);
        }

        private IEnumerable<MContent> getDummyContents()
        {
            var content1 = new MContent();
            content1.Name = "001";
            content1.Type = "txt";
            content1.Values["EN"] = "one";

            var content2 = new MContent();
            content2.Name = "002";
            content2.Type = "jpg";
            content2.Values["EN"] = "two";

            var list = new List<MContent>();
            list.Add(content1);
            list.Add(content2);
            IEnumerable<MContent> dummy = (IEnumerable<MContent>)list;
            return dummy;
        }
    }
}