using System;

using Its.Onix.Erp.Utils;
using Its.Onix.Erp.Databases;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Factories;
using Its.Onix.Erp.Businesses.Commons;

namespace Its.Onix.Erp.Businesses.Commons
{
	public class OperationTestBase
	{
        protected OnixErpDbContext CreateOnixDbContext(string db, string provider)
        {
            OnixErpDbContext ctx = null;

            if (provider.Equals("pgsql"))
            {
                string host = Environment.GetEnvironmentVariable("ONIX_ERP_DB_HOST");
                DbCredential crd = new DbCredential(host, 5432, "onix_erp", "postgres", "", provider);
                ctx = new OnixErpDbContext(crd);
            }                    
            else if (provider.Equals("sqlite_inmem"))
            {
                DbCredential crd = new DbCredential("", 9999, "", "", "", provider);
                ctx = new OnixErpDbContext(crd);
                ctx.Database.EnsureCreated();
            }    

            FactoryBusinessOperation.SetDatabaseContext(ctx);
            return ctx;
        }

        protected ManipulationOperation CreateManipulateOperation(string name)
        {
            var opr = (ManipulationOperation) FactoryBusinessOperation.CreateBusinessOperationObject(name);
            return opr;
        }        

        public OperationTestBase()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }
    }
}
