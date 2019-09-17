using System;
using System.Collections.Generic;

namespace Its.Onix.Erp.Services
{   
    public static class BusinessErpCaches
    {
        private static Dictionary<string, string> classMaps = new Dictionary<string, string>();

        public static Dictionary<string, string> GetCachesList()
        {
            return classMaps;
        }

        private static void AddClassConfig(string apiName, string fqdn)
        {
            classMaps.Add(apiName, fqdn);
        }

        static BusinessErpCaches()
        {
            InitClassMap();
        }

        private static void InitClassMap()
        {
            AddClassConfig("CreateBarcode", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Barcodes.CreateBarcode");
            AddClassConfig("CreateRegistration", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Registrations.CreateRegistration");
            AddClassConfig("ResetRegistration", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Registrations.ResetRegistration");
        }  
    } 
}
