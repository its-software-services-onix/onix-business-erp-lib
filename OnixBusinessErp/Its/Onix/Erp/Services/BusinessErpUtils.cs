using System;
using System.Reflection;
using System.Collections.Generic;

using Its.Onix.Core.Commons.Plugin;

namespace Its.Onix.Erp.Services
{   
    public static class BusinessErpUtils
    {
        public static void AddClassConfig(Dictionary<string, PluginEntry> classMaps, Assembly asm, string apiName, string fqdn)
        {
            PluginEntry entry = new PluginEntry(asm, apiName, fqdn);
            classMaps.Add(apiName, entry);
        }        
    }
}