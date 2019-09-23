using System;
using NUnit.Framework;

using Moq;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Databases;
using Its.Onix.Erp.Utils;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Masters
{
	public class SaveMasterTest
	{
        public SaveMasterTest()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [SetUp]
        public void Setup()
        {            
        }

        [TestCase]
        public void SaveMasterOperationTest()
        {
            DbCredential crd = new DbCredential("130.211.245.2", 5432, "onix_erp", "postgres", "", "pgsql");
            OnixErpDbContext ctx = new OnixErpDbContext(crd);
            Master m = new Master() { Code = "00", Name = "Master01", Type = 1 };

            FactoryBusinessOperation.SetDatabaseContext(ctx);
            var opr = (ManipulationOperation) FactoryBusinessOperation.CreateBusinessOperationObject("SaveMaster");

            opr.Apply(m);
        } 
    }
}
