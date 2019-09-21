using System;
using System.Reflection;
using System.Collections.Generic;

using Its.Onix.Core.Commons.Plugin;

namespace Its.Onix.Erp.Services
{   
    public static class BusinessErpCaches
    {
        private static Dictionary<string, PluginEntry> classMaps = new Dictionary<string, PluginEntry>();

        public static Dictionary<string, PluginEntry> BusinessErpCachesList()
        {
            return classMaps;
        }

        static BusinessErpCaches()
        {
            InitClassMap();
        }

        private static void InitClassMap()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            BusinessErpUtils.AddClassConfig(classMaps, asm, "CacheProductTypeList", "Its.Onix.Erp.Caches.CacheProductTypeList");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "CacheProductList", "Its.Onix.Erp.Caches.CacheProductList");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "CachePageContents", "Its.Onix.Erp.Caches.CachePageContents");
        }  
    } 
}