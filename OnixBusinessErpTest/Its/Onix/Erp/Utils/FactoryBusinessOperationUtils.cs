using System;

using Its.Onix.Core.Factories;
using Its.Onix.Erp.Services;

namespace Its.Onix.Erp.Utils
{
	public static class FactoryBusinessOperationUtils
	{
        private static bool isLoad = false;

        public static void LoadBusinessOperations()
        {
            if (!isLoad)
            {
                FactoryBusinessOperation.RegisterBusinessOperations(BusinessErpOperations.GetBusinessOperationList());
                isLoad = true;
            }
        }
    }
}