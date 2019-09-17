using System.Collections.Generic;
using Its.Onix.Core.Caches;
using Its.Onix.Core.Business;
using Its.Onix.Core.Factories;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Caches
{
    public class CacheProductTypeList : CacheBase
    {
        private IBusinessOperationQuery<MProductType> opr;

        public CacheProductTypeList()
        {
            opr = (IBusinessOperationQuery<MProductType>)FactoryBusinessOperation.CreateBusinessOperationObject("GetProductTypeList");
        }

        protected override Dictionary<string, BaseModel> LoadContents()
        {
            var map = new Dictionary<string, BaseModel>();
            IEnumerable<MProductType> mProductTypes = opr.Apply(null, null);

            foreach (var productType in mProductTypes)
            {
                map[productType.Code] = productType;
            }

            return map;
        }

        public void SetOperation(IBusinessOperationQuery<MProductType> opr)
        {
            this.opr = opr; 
        }
    }
}