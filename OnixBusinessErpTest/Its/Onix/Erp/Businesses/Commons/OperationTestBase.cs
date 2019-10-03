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

        protected IsExistOperation CreateIsExistOperation(string name)
        {
            var opr = (IsExistOperation) FactoryBusinessOperation.CreateBusinessOperationObject(name);
            return opr;
        }  

        protected bool UpdateNotFoundOperation<T>(string db, string provider, TestOperationParam param) where T : BaseModel
        {
            bool result = false;
        
            try
            {
                CreateOnixDbContext(db, provider);
                var updateOpr = CreateManipulateOperation(param.SaveOprName);

                T m1 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m1, param.PkFieldName);
                TestUtils.SetPropertyValue(m1, param.PkFieldName, 69696); //Not found ID earlier

                updateOpr.Apply(m1);
            } 
            catch (Exception e)
            {
                //Not found to update
                Console.WriteLine(e);  
                result = true;
            }

            return result;                
        }

        protected bool UpdateOperation<T>(string db, string provider, bool withDuplicate, TestOperationParam param) where T : BaseModel
        {
            bool result = true;
        
            try
            {
                CreateOnixDbContext(db, provider);
                var saveOpr = CreateManipulateOperation(param.SaveOprName);

                T m1 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m1, param.PkFieldName);
                string code = (string) TestUtils.GetPropertyValue(m1, param.KeyFieldName);              
                saveOpr.Apply(m1);

                //Create another one with different key
                T m2 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m2, param.PkFieldName);
                saveOpr.Apply(m2);

                //Update the existing ID with or without duplicate key
                if (withDuplicate)
                {
                    //Should throw exception from here
                    TestUtils.SetPropertyValue(m2, param.KeyFieldName, code);
                }
                saveOpr.Apply(m2);                
            } 
            catch (Exception e)
            {
                //Duplicate key exception
                Console.WriteLine(e);  
                result = withDuplicate;
            }

            return result;                
        }

        protected bool CreateOperation<T>(string db, string provider, bool withDuplicate, TestOperationParam param) where T : BaseModel
        {
            bool result = true;
        
            try
            {
                CreateOnixDbContext(db, provider);
                var opr = CreateManipulateOperation(param.SaveOprName);

                T m1 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m1, param.PkFieldName);
                string code = (string) TestUtils.GetPropertyValue(m1, param.KeyFieldName);              
                opr.Apply(m1);

                T m2 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m2, param.PkFieldName);
                if (withDuplicate)
                {
                    TestUtils.SetPropertyValue(m2, param.KeyFieldName, code);                    
                }
                opr.Apply(m2);
            } 
            catch (Exception e)
            {
                //Duplicate key exception
                Console.WriteLine(e);  
                result = withDuplicate;
            }

            return result;                
        }

        protected bool DeleteOperationWithExisting<T>(string db, string provider, TestOperationParam param) where T : BaseModel
        {
            CreateOnixDbContext(db, provider);     

            var addOpr = CreateManipulateOperation(param.SaveOprName);

            T createdObj = (T)Activator.CreateInstance(typeof(T));
            TestUtils.PopulateDummyPropValues(createdObj, param.PkFieldName);
            addOpr.Apply(createdObj);
            int createdId = (int)TestUtils.GetPropertyValue(createdObj, param.PkFieldName);

            bool ok = true;
            var delOpr = CreateManipulateOperation(param.DeleteOprName);

            try
            {
                delOpr.Apply(createdObj);                
            }
            catch (Exception e)
            {
                //Should not error because data already exist, so should be able to delete
                Console.WriteLine(e);
                ok = false;
            }

            return ok;
        }

        protected bool DeleteOperationWithNotExist<T>(string db, string provider, TestOperationParam param) where T : BaseModel
        {
            CreateOnixDbContext(db, provider);     

            bool ok = false;
            var opr = CreateManipulateOperation(param.DeleteOprName);
            
            T m = (T) Activator.CreateInstance(typeof(T));            
            int id = -9999;
            TestUtils.SetPropertyValue(m, param.PkFieldName, id);

            try
            {
                opr.Apply(m);                
            }
            catch
            {
                //Should error because data not found
                //Success if exception is thrown
                ok = true;
            }

            return ok;
        }

        protected bool IsExistFromOperation<T>(string db, string provider, TestOperationParam param) where T : BaseModel
        {
            CreateOnixDbContext(db, provider);            

            int createdId = 0;
            T createdObj = null;
            if (param.CreateDummyRecord)
            {
                var addOpr = CreateManipulateOperation(param.SaveOprName);

                createdObj = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(createdObj, param.PkFieldName);
                TestUtils.SetPropertyValue(createdObj, param.KeyFieldName, "UNIQUE_KEY_HERE");
                addOpr.Apply(createdObj);

                createdId = (int) TestUtils.GetPropertyValue(createdObj, param.PkFieldName);
            }

            var opr = CreateIsExistOperation(param.IsExistOprName);            
            T m1 = (T)Activator.CreateInstance(typeof(T));
            if (param.Mode.Equals("edit"))
            {
                if (param.CreateDummyRecord)
                {
                    TestUtils.PopulateDummyPropValues(m1); //Simulate update itself
                    if (param.IsExistSelfIdCheck)
                    {
                        TestUtils.SetPropertyValue(m1, param.PkFieldName, createdId);
                    } 
                    else
                    {
                        TestUtils.PopulateDummyPropValues(m1); //Simulate update record
                    }                                                                             
                }
            }            
            else
            {
                TestUtils.PopulateDummyPropValues(m1, param.PkFieldName); //Simulate create new record
            }
            TestUtils.SetPropertyValue(m1, param.KeyFieldName, "UNIQUE_KEY_HERE");

            bool isExist = opr.Apply(m1);

            if (param.CreateDummyRecord)
            {
                var delOpr = CreateManipulateOperation(param.DeleteOprName);
                delOpr.Apply(createdObj);
            }

            return isExist;
        }           

        public OperationTestBase()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }
    }
}
