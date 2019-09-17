using System;
using System.Collections.Generic;

namespace Its.Onix.Erp.Services
{   
    public static class BusinessErpCaches
    {
        private static Dictionary<string, string> classMaps = new Dictionary<string, string>();

        public static Dictionary<string, string> BusinessErpCachesList()
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
            AddClassConfig("CacheProductTypeList", "OnixBusinessErp.dll:Its.Onix.Erp.Caches.CacheProductTypeList");
            AddClassConfig("CacheProductList", "OnixBusinessErp.dll:Its.Onix.Erp.Caches.CacheProductList");
            AddClassConfig("CachePageContents", "OnixBusinessErp.dll:Its.Onix.Erp.Caches.CachePageContents");
        }  
    } 
}