using System;
using System.Linq;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
    public class GetMasterInfo : GetInfoOperation
    {      
        protected override int GetId(BaseModel dat)
        {
            Master m = (Master) dat;
            int id = m.MasterId; 

            return id;
        }

        protected override BaseModel GetObject(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            Master m = (Master) dat;
            int id = m.MasterId;   

            var o = ctx.Masters
                    .Where(s => s.MasterId == id)
                    .FirstOrDefault();
    
            return o;
        }
    }
}
