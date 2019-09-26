using System;

using Its.Onix.Erp.Utils;
using Its.Onix.Erp.Databases;
using Its.Onix.Core.Databases;
using Its.Onix.Core.Factories;
using Its.Onix.Core.Commons.Model;

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

        protected bool IsDuplicateUniqueCheckOk<T>(string db, string provider, string name, string pk, string dupKey) where T : BaseModel
        {
            bool result = false;
            var opr = CreateManipulateOperation(name);

            try
            {
                T m1 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m1, pk);                
                opr.Apply(m1);
                                
                string code = (string) TestUtils.GetPropertyValue(m1, dupKey);

                T m2 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m2, pk); 
                TestUtils.SetPropertyValue(m2, dupKey, code);
                opr.Apply(m2);
            } 
            catch (Exception e)
            {
                //Duplicate key exception
                //Console.WriteLine(e);  
                result = true;
            }      

            return result;             
        }

        protected bool IsDuplicateUniqueKeyDifferentCheckOk<T>(string db, string provider, string name, string pk) where T : BaseModel
        {
            bool result = true;
            var opr = CreateManipulateOperation(name);

            try
            {
                T m1 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m1, pk);
                
                opr.Apply(m1);
                                
                T m2 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m2, pk);

                opr.Apply(m2);
            } 
            catch (Exception e)
            {
                //Duplicate key exception
                Console.WriteLine(e);  
                result = false;
            }      

            return result;             
        }

        protected bool IsDuplicateUniqueKeyOk<T>(string db, string provider, string name, string pk, string keyCol) where T : BaseModel
        {
            CreateOnixDbContext(db, provider);

            bool isOK1 = IsDuplicateUniqueCheckOk<T>(db, provider, name, pk, keyCol);
            bool isOK2 = IsDuplicateUniqueKeyDifferentCheckOk<T>(db, provider, name, pk);

            return (isOK1 && isOK2);
        }

        protected bool IsSaveOperationOk<T>(string db, string provider, string saveName, string delName, string pk) where T : BaseModel
        {
            bool ok = true;
            CreateOnixDbContext(db, provider);

            var opr = CreateManipulateOperation(saveName);
            var del = CreateManipulateOperation(delName);
            
            T m = null;
            try
            {
                m = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m, pk);
                T o = (T) opr.Apply(m);

                del.Apply(o);
            }
            catch (Exception e)
            {
                //Exception if no data to delete
                Console.WriteLine(e);                
                ok = false;
            }

            return ok;
        }        

        public OperationTestBase()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }
    }
}
