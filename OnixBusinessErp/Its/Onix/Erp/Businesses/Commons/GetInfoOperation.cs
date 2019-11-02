using System;

using Its.Onix.Core.Business;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Core.Databases;

namespace Its.Onix.Erp.Businesses.Commons
{
    public abstract class GetInfoOperation : BusinessOperationBase
    {
        protected BaseDbContext context = null;

        protected abstract int GetId(BaseModel dat);
        protected abstract BaseModel GetObject(BaseModel dat);

        public BaseModel Apply(BaseModel dat)
        {
            context = GetDatabaseContext();                    

            int id = GetId(dat);
            if (id <= 0)
            {
                throw new ArgumentException("Value of primary key field should be specified!!!");
            }

            BaseModel o = GetObject(dat);
            return o;
        }
    }
}
