using System;
using System.Linq;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.Masters
{
    public class GetMasterInfo : GetInfoOperation
    {      
        protected override int GetId(BaseModel dat)
        {
            Master m = (Master) dat;
            int id = (int) m.MasterId; 

            return id;
        }

        protected override BaseModel GetObject(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            Master m = (Master) dat;
            int id = ConvertUtils.NullableToInt(m.MasterId, 0); 

            var o = ctx.Masters
                    .Where(s => s.MasterId == id)
                    .FirstOrDefault();
    
            return o;
        }
    }
}
