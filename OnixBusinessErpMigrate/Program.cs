using System;

using Its.Onix.Erp.Databases;
using Its.Onix.Core.Databases;

namespace OnixBusinessErpApp
{
    public class OnixErpDbContextPgSql : OnixErpDbContext
    {
        public OnixErpDbContextPgSql() : base(new DbCredential("130.211.245.2", 5432, "onix_erp", "postgres", "", "pgsql"))
        {            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
