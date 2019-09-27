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
        protected OnixErpDbContext context = null;

        protected virtual BaseModel Execute(BaseModel dat)
        {
            throw new NotImplementedException();
        }

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
            catch (DbUpdateException e)
            {
                throw new DbUpdateException("Update exception occur in ManipulationOperation.Apply()", e);
            }  
            catch (Exception e)
            {
                throw new InvalidOperationException("Generic exception occur in ManipulationOperation.Apply()", e);
            }                        
            finally
            {
                DetachAllEntities(context);
            }

            return obj;
        }
    }
}
