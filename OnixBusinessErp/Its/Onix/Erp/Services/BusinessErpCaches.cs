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

        private static void AddClassConfig(Assembly asm, string name, string fqdn)
        {
            PluginEntry entry = new PluginEntry(asm, name, fqdn);
            classMaps.Add(name, entry);
        }

        static BusinessErpCaches()
        {
            InitClassMap();
        }

        private static void InitClassMap()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            AddClassConfig(asm, "CacheProductTypeList", "Its.Onix.Erp.Caches.CacheProductTypeList");
            AddClassConfig(asm, "CacheProductList", "Its.Onix.Erp.Caches.CacheProductList");
            AddClassConfig(asm, "CachePageContents", "Its.Onix.Erp.Caches.CachePageContents");
        }  
    } 
}