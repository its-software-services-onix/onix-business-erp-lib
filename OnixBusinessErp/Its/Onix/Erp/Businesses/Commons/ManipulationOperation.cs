using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Its.Onix.Core.Business;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Databases;

namespace Its.Onix.Erp.Businesses.Commons
{
    public abstract class ManipulationOperation : BusinessOperationBase
    {
        protected abstract BaseModel Execute(BaseModel dat);
        protected OnixErpDbContext context = null;

        private void DetachAllEntities(OnixErpDbContext context)
        {
            var changedEntriesCopy = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
            {
                entry.State = EntityState.Detached;
            }
        }

        public BaseModel Apply(BaseModel dat)
        {
            BaseModel obj = null;
            context = (OnixErpDbContext) GetDatabaseContext();

            try
            {
                obj = Execute(dat);
            }
            catch (Exception e)
            {
                DetachAllEntities(context);
                throw(e);
            }
            finally
            {
                DetachAllEntities(context);
            }

            return obj;
        }
    }
}
