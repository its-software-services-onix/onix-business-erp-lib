using System.Collections;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest.Executors
{
    public class ManipulateExecutor : BaseOperationExecutor
    {
        protected override object Apply(string oprName, BaseModel m)
        {
            var mnplOpr = (ManipulationOperation) FactoryBusinessOperation.CreateBusinessOperationObject(oprName); 
            BaseModel o = mnplOpr.Apply(m);

            return o;
        }
    }
}