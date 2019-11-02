using System.Collections.Generic;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Core.Commons.Table;

namespace Its.Onix.Erp.Businesses.ProductTypes
{
	public class GetProductTypeList : BusinessOperationBase, IBusinessOperationQuery<MProductType>
	{
        public IEnumerable<MProductType> Apply(MProductType dat, CTable param)
        {
            //Parameter "dat" can be use for create the filter in the future
            var ctx = GetNoSqlContext();
            IEnumerable<MProductType> products = ctx.GetObjectList<MProductType>("product_types");

            return products;
        }
    }
}
