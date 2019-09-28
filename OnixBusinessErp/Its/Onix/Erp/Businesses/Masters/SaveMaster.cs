using System;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Databases;

namespace Its.Onix.Erp.Businesses.Masters
{
    public class SaveMaster : ManipulationOperation
    {        
        protected override BaseModel Execute(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            Master m = (Master) dat;

            if (m.MasterId <= 0)
            {
                ctx.Masters.Add(m);
            }
            else
            {
                ctx.Masters.Update(m);
            }

            ctx.SaveChanges();
            return m;

        }
    }
}
