using System.Collections;
using Microsoft.Extensions.Logging;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest.Executors
{
    public interface IOperationExecutor
    {
        string ExecuteOperation(string oprName, Hashtable args);
        string ExecuteGetListOperation(string oprName, Hashtable args);
        void SetLogger(ILogger logger);
    }
}