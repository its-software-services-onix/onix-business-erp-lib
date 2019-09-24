using System;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.ContactUs
{
	public class SaveContactUs : BusinessOperationBase, IBusinessOperationManipulate<MContactUs>
	{
        public int Apply(MContactUs dat)
        {
            DateTime currentDate = DateTime.Now;
            dat.LastMaintDate = currentDate;

            string path = string.Format("contactus/{0}/{1}", currentDate.Year, currentDate.Month);
            
            var ctx = GetNoSqlContext();
            ctx.PostData(path, dat);

            return 0;
        }
    }
}
