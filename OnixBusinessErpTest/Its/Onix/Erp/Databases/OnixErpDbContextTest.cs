using System;
using NUnit.Framework;

using Its.Onix.Core.Databases;

namespace Its.Onix.Erp.Databases
{
	public class OnixErpDbContextTest
	{
        [SetUp]
        public void Setup()
        {        
        }

        [TestCase("130.211.245.2", 5432, "onix_erp", "postgres", "", "pgsql")]
        [TestCase("130.211.245.2", 5432, "onix_erp", "postgres", "", "")]
        public void OnixErpDbContextConnectTest(string host, int port, string db, string user, string passwd, string provider)
        {
            var credential = new DbCredential(host, port, db, user, passwd, provider);
            OnixErpDbContext ctx = new OnixErpDbContext(credential);
        }
    }
}
