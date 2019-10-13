using System;
using Its.Onix.Erp.Databases;
using Its.Onix.Core.Databases;

namespace OnixBusinessErpApp
{
    public class OnixErpDbContextPgSql : OnixErpDbContext
    {
        private static string defaultHost = Environment.GetEnvironmentVariable("ONIX_ERP_DB_HOST");

        public OnixErpDbContextPgSql() : base(new DbCredential(defaultHost, 5432, "onix_erp", "postgres", "", "pgsql"))
        {
            //Pass the IP address when issuing command "dotnet ef migrations remove"            
        }

        public OnixErpDbContextPgSql(DbCredential crd) : base(crd)
        {            
        }
    }
}