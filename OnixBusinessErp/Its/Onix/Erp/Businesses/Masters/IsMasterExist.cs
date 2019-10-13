using System;
using System.Linq;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.Masters
{
    public class IsMasterExist : IsExistOperation
    {      
        protected override int GetId(BaseModel dat)
        {
            Master m = (Master) dat;
            int id = ConvertUtils.NullableToInt(m.MasterId, 0); 

            return id;
        }

        protected override BaseModel GetObject(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            Master m = (Master) dat;
            string key = m.Code;   

            var o = ctx.Masters
                    .Where(s => s.Code.Equals(key))
                    .FirstOrDefault();
    
            return o;
        }
    }
}
