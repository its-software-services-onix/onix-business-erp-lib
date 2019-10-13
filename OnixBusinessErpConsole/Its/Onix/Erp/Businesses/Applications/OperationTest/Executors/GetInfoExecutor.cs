using System.Collections;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest.Executors
{
    public class GetInfoExecutor : BaseOperationExecutor
    {
        protected override object Apply(string oprName, BaseModel m)
        {
            var getInfoOpr = (GetInfoOperation) FactoryBusinessOperation.CreateBusinessOperationObject(oprName); 
            BaseModel o = getInfoOpr.Apply(m);

            return o;
        }
    }
}