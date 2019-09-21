using System;

using Its.Onix.Core.Factories;
using Its.Onix.Erp.Services;

namespace Its.Onix.Erp.Utils
{
	public static class FactoryBusinessOperationUtils
	{
        public static void LoadBusinessOperations()
        {
            FactoryBusinessOperation.ClearRegisteredItems();
            FactoryBusinessOperation.RegisterBusinessOperations(BusinessErpOperations.GetInstance().ExportedServicesList());
        }
    }
}