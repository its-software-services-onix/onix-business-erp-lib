using System;
using System.Collections.Generic;

using Its.Onix.Core.Caches;
using Its.Onix.Core.Business;
using Its.Onix.Core.Factories;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Caches
{
    public class CachePageContents : CacheBase
    {
        private IBusinessOperationQuery<MContent> opr;

        public CachePageContents()
        {
            opr = (IBusinessOperationQuery<MContent>)FactoryBusinessOperation.CreateBusinessOperationObject("GetContentList");
        }

        public CachePageContents(string profile)
        {
            opr = (IBusinessOperationQuery<MContent>)FactoryBusinessOperation.CreateBusinessOperationObject(profile, "GetContentList");
        }

        protected override Dictionary<string, BaseModel> LoadContents()
        {
            var map = new Dictionary<string, BaseModel>();
            IEnumerable<MContent> mContents = opr.Apply(null, null);

            foreach (var content in mContents)
            {
                map[content.Type + "/" + content.Name] = content;
            }

            return map;
        }

        public void SetOperation(IBusinessOperationQuery<MContent> opr)
        {
            this.opr = opr; 
        }
    }
}