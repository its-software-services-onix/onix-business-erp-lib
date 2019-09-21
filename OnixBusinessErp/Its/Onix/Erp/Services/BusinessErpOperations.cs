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

        static BusinessErpOperations()
        {
            InitClassMap();
        }

        private static void InitClassMap()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            BusinessErpUtils.AddClassConfig(classMaps, asm, "CreateBarcode", "Its.Onix.Erp.Businesses.Barcodes.CreateBarcode");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "CreateRegistration", "Its.Onix.Erp.Businesses.Registrations.CreateRegistration");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "ResetRegistration", "Its.Onix.Erp.Businesses.Registrations.ResetRegistration");
            
            BusinessErpUtils.AddClassConfig(classMaps, asm, "SaveProduct", "Its.Onix.Erp.Businesses.Products.SaveProduct");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "DeleteProduct", "Its.Onix.Erp.Businesses.Products.DeleteProduct");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "GetProductInfo", "Its.Onix.Erp.Businesses.Products.GetProductInfo");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "GetProductList", "Its.Onix.Erp.Businesses.Products.GetProductList");   

            BusinessErpUtils.AddClassConfig(classMaps, asm, "GetProductTypeList", "Its.Onix.Erp.Businesses.ProductTypes.GetProductTypeList"); 
            BusinessErpUtils.AddClassConfig(classMaps, asm, "GetProductTypeInfo", "Its.Onix.Erp.Businesses.ProductTypes.GetProductTypeInfo");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "SaveProductType", "Its.Onix.Erp.Businesses.ProductTypes.SaveProductType");

            BusinessErpUtils.AddClassConfig(classMaps, asm, "SaveContactUs", "Its.Onix.Erp.Businesses.ContactUs.SaveContactUs");

            BusinessErpUtils.AddClassConfig(classMaps, asm, "GetContentList", "Its.Onix.Erp.Businesses.Contents.GetContentList");
            BusinessErpUtils.AddClassConfig(classMaps, asm, "SaveContent", "Its.Onix.Erp.Businesses.Contents.SaveContent");
        }  
    } 
}