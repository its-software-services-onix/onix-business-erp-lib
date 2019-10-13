using System.Collections;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest.Executors
{
    public class IsExistExecutor : BaseOperationExecutor
    {
        protected override object Apply(string oprName, BaseModel m)
        {
            var isExistOpr = (IsExistOperation) FactoryBusinessOperation.CreateBusinessOperationObject(oprName); 
            bool isExist = isExistOpr.Apply(m);

            return isExist;
        }
    }
}