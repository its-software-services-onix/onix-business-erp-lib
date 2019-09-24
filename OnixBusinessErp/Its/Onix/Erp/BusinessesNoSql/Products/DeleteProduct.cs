using System;
using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.Products
{
	public class DeleteProduct : BusinessOperationBase, IBusinessOperationManipulate<MProduct>
	{
        public int Apply(MProduct dat)
        {
            if (!dat.IsKeyIdentifiable())
            {
                throw(new ArgumentException("Code must not be null!!!"));
            }

            var ctx = GetNoSqlContext();
            string prdPath = string.Format("products/{0}", dat.Code);
            int rowAffected = ctx.DeleteData(prdPath, dat);

            return rowAffected;
        }
    }
}
