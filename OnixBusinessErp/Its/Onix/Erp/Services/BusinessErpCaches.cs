using System;
using System.Reflection;

namespace Its.Onix.Erp.Services
{   
    public class BusinessErpCaches : BusinessErpBase
    {
        private static BusinessErpCaches instance = new BusinessErpCaches();

        private BusinessErpCaches() : base()
        {
        }

        public static BusinessErpCaches GetInstance()
        {
            return instance;
        }

        protected override void InitClassMap()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            AddClassConfig(asm, "CacheProductTypeList", "Its.Onix.Erp.Caches.CacheProductTypeList");
            AddClassConfig(asm, "CacheProductList", "Its.Onix.Erp.Caches.CacheProductList");
            AddClassConfig(asm, "CachePageContents", "Its.Onix.Erp.Caches.CachePageContents");
        }  
    } 
}