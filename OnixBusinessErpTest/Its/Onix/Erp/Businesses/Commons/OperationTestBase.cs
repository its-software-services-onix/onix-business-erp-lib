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

        protected bool IsCreateDuplicateUniqueCheckOk<T>(string db, string provider, string name, string pk, string dupKey) where T : BaseModel
        {
            bool result = false;

            try
            {
                CreateOnixDbContext(db, provider);
                var opr = CreateManipulateOperation(name);

                T m1 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m1, pk);                
                opr.Apply(m1);
                                
                string code = (string) TestUtils.GetPropertyValue(m1, dupKey);

                T m2 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m2, pk); 
                TestUtils.SetPropertyValue(m2, dupKey, code);
                opr.Apply(m2);
            } 
            catch //(Exception e)
            {
                //Duplicate key exception
                //Console.WriteLine(e);  
                result = true;
            }      

            return result;             
        }

        protected bool IsCreateDuplicateUniqueKeyDifferentCheckOk<T>(string db, string provider, string name, string pk) where T : BaseModel
        {
            bool result = true;
        
            try
            {
                CreateOnixDbContext(db, provider);
                var opr = CreateManipulateOperation(name);

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

            bool isOK1 = IsCreateDuplicateUniqueCheckOk<T>(db, provider, name, pk, keyCol);
            bool isOK2 = IsCreateDuplicateUniqueKeyDifferentCheckOk<T>(db, provider, name, pk);

            return (isOK1 && isOK2);
        }

        protected bool IsSaveCreateOperationOk<T>(string db, string provider, string saveName, string delName, string pk) where T : BaseModel
        {
            bool ok = true;
            CreateOnixDbContext(db, provider);

            var opr = CreateManipulateOperation(saveName);
            var del = CreateManipulateOperation(delName);
            
            try
            {
                T m1 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m1, pk);
                T o1 = (T) opr.Apply(m1);

                del.Apply(o1);
            }
            catch (Exception e)
            {
                //Exception if no data to delete
                Console.WriteLine(e);                
                ok = false;
            }

            return ok;
        }        

        protected bool IsSaveUpdateOperationOk<T>(string db, string provider, string saveName, string delName, string pk) where T : BaseModel
        {
            bool ok = true;
            CreateOnixDbContext(db, provider);

            var opr = CreateManipulateOperation(saveName);
            var del = CreateManipulateOperation(delName);
            
            try
            {
                T m1 = (T) Activator.CreateInstance(typeof(T));
                TestUtils.PopulateDummyPropValues(m1, pk);
                T o1 = (T) opr.Apply(m1);

                int createdId = (int) TestUtils.GetPropertyValue(o1, pk);

                TestUtils.PopulateDummyPropValues(o1);
                TestUtils.SetPropertyValue(o1, pk, createdId);
                opr.Apply(o1);

                del.Apply(o1);
            }
            catch (Exception e)
            {
                //Exception if no data to delete
                Console.WriteLine(e);                
                ok = false;
            }

            return ok;
        }         

        protected bool IsDeleteNotFoundOk<T>(string db, string provider, string delName, string pk) where T : BaseModel
        {
            bool ok = false;
            CreateOnixDbContext(db, provider);
            var opr = CreateManipulateOperation(delName);
            
            T m = (T) Activator.CreateInstance(typeof(T));
            //Key not exist
            TestUtils.SetPropertyValue(m, pk, -9999);

            try
            {
                opr.Apply(m);                
            }
            catch
            {
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
