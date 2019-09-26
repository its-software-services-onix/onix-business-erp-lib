using System;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
    public class SaveMaster : ManipulationOperation
    {        
        protected override BaseModel Execute(BaseModel dat)
        {
            Master m = (Master) dat;
            context.Masters.Add(m);
/*
            if (m.MasterId <= 0)
            {
                context.Masters.Add(m);
            }
            else
            {
                context.Masters.Update(m);
            }
*/            
            context.SaveChanges();

            return m;
        }
    }
}
