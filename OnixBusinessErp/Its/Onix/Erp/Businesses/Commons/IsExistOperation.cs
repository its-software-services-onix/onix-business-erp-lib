using Its.Onix.Core.Business;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Core.Databases;

namespace Its.Onix.Erp.Businesses.Commons
{
    public abstract class IsExistOperation : BusinessOperationBase
    {
        protected BaseDbContext context = null;

        protected abstract int GetId(BaseModel dat);
        protected abstract BaseModel GetObject(BaseModel dat);

        public bool Apply(BaseModel dat)
        {
            context = GetDatabaseContext();
            
            BaseModel o = GetObject(dat);

            if (o == null)
            {
                //Not exist
                return false;
            }
            
            int id = GetId(dat);
            if (id <= 0)
            {
                //Add mode and key already exist
                return true;
            }

            int objId = GetId(o);
            if (objId == id)
            {
                //It self, not count as duplicate
                return false;
            }

            return true;
        }
    }
}
