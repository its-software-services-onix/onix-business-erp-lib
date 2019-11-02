using System.Reflection;
using System.Collections.Generic;

using Its.Onix.Core.Commons.Plugin;

namespace Its.Onix.Erp.Services
{   
    public abstract class BusinessErpBase
    {
        private readonly Dictionary<string, PluginEntry> classMaps = new Dictionary<string, PluginEntry>();

        protected void AddClassConfig(Assembly asm, string apiName, string fqdn)
        {
            PluginEntry entry = new PluginEntry(asm, apiName, fqdn);
            classMaps.Add(apiName, entry);
        } 

        protected Dictionary<string, PluginEntry> GetClassMaps()
        {
            return classMaps;
        }

        public Dictionary<string, PluginEntry> ExportedServicesList()
        {
            return GetClassMaps();
        }        
    } 
}