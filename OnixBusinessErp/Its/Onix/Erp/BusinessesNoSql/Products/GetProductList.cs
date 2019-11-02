using System.Collections.Generic;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Core.Commons.Table;

namespace Its.Onix.Erp.Businesses.Products
{
	public class GetProductList : BusinessOperationBase, IBusinessOperationQuery<MProduct>
	{
        public IEnumerable<MProduct> Apply(MProduct dat, CTable param)
        {
            //Parameter "dat" can be use for create the filter in the future
            var ctx = GetNoSqlContext();
            IEnumerable<MProduct> products = ctx.GetObjectList<MProduct>("products");

            return products;
        }
    }
}
