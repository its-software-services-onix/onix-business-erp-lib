using System;
using System.Reflection;
using System.Collections.Generic;

using Its.Onix.Core.Commons.Plugin;

namespace Its.Onix.Erp.Services
{   
    public static class BusinessErpOperations
    {
        private static Dictionary<string, PluginEntry> classMaps = new Dictionary<string, PluginEntry>();

        public static Dictionary<string, PluginEntry> GetBusinessOperationList()
        {
            return classMaps;
        }

        private static void AddClassConfig(Assembly asm, string apiName, string fqdn)
        {
            PluginEntry entry = new PluginEntry(asm, apiName, fqdn);
            classMaps.Add(apiName, entry);
        }

        static BusinessErpOperations()
        {
            InitClassMap();
        }

        private static void InitClassMap()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            AddClassConfig(asm, "CreateBarcode", "Its.Onix.Erp.Businesses.Barcodes.CreateBarcode");
            AddClassConfig(asm, "CreateRegistration", "Its.Onix.Erp.Businesses.Registrations.CreateRegistration");
            AddClassConfig(asm, "ResetRegistration", "Its.Onix.Erp.Businesses.Registrations.ResetRegistration");
            
            AddClassConfig(asm, "SaveProduct", "Its.Onix.Erp.Businesses.Products.SaveProduct");
            AddClassConfig(asm, "DeleteProduct", "Its.Onix.Erp.Businesses.Products.DeleteProduct");
            AddClassConfig(asm, "GetProductInfo", "Its.Onix.Erp.Businesses.Products.GetProductInfo");
            AddClassConfig(asm, "GetProductList", "Its.Onix.Erp.Businesses.Products.GetProductList");   

            AddClassConfig(asm, "GetProductTypeList", "Its.Onix.Erp.Businesses.ProductTypes.GetProductTypeList"); 
            AddClassConfig(asm, "GetProductTypeInfo", "Its.Onix.Erp.Businesses.ProductTypes.GetProductTypeInfo");
            AddClassConfig(asm, "SaveProductType", "Its.Onix.Erp.Businesses.ProductTypes.SaveProductType");

            AddClassConfig(asm, "SaveContactUs", "Its.Onix.Erp.Businesses.ContactUs.SaveContactUs");

            AddClassConfig(asm, "GetContentList", "Its.Onix.Erp.Businesses.Contents.GetContentList");
            AddClassConfig(asm, "SaveContent", "Its.Onix.Erp.Businesses.Contents.SaveContent");
        }  
    } 
}