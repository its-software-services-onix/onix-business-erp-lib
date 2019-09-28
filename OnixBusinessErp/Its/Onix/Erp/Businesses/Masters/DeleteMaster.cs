using System;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Databases;

namespace Its.Onix.Erp.Businesses.Masters
{
    public class DeleteMaster : ManipulationOperation
    {        
        protected override BaseModel Execute(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            Master m = (Master) dat;
            ctx.Masters.Remove(m);
            ctx.SaveChanges();

            return m;
        }
    }
}
