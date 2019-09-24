using System;

using Its.Onix.Core.Business;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Databases;

namespace Its.Onix.Erp.Businesses.Commons
{
    public abstract class ManipulationOperation : BusinessOperationBase
    {
        protected abstract BaseModel Execute(BaseModel dat);
        protected OnixErpDbContext context = null;

        public BaseModel Apply(BaseModel dat)
        {
            BaseModel obj = null;
            context = (OnixErpDbContext) GetDatabaseContext();
            obj = Execute(dat);

            //Let consider begin transaction in the future

            return obj;
        }
    }
}
