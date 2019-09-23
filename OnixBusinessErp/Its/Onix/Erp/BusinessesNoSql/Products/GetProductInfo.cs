using System;
using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.Products
{
	public class GetProductInfo : BusinessOperationBase, IBusinessOperationGetInfo<MProduct>
	{
        public MProduct Apply(MProduct dat)
        {
            if (!dat.IsKeyIdentifiable())
            {
                throw(new ArgumentException("Code and Key must not be null!!!"));
            }

            var ctx = GetNoSqlContext();
            MProduct prd = ctx.GetSingleObject<MProduct>("products", dat.Code);

            return prd;
        }
    }
}
