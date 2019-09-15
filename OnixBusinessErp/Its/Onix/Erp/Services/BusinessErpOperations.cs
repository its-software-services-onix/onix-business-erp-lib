using System;
using System.Collections.Generic;

namespace Its.Onix.Erp.Services
{   
    public static class BusinessErpOperations
    {
        private static Dictionary<string, string> classMaps = new Dictionary<string, string>();

        public static Dictionary<string, string> GetBusinessOperationList()
        {
            return classMaps;
        }

        private static void AddClassConfig(string apiName, string fqdn)
        {
            classMaps.Add(apiName, fqdn);
        }

        static BusinessErpOperations()
        {
            InitClassMap();
        }

        private static void InitClassMap()
        {
            AddClassConfig("CreateBarcode", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Barcodes.CreateBarcode");
            AddClassConfig("CreateRegistration", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Registrations.CreateRegistration");
            AddClassConfig("ResetRegistration", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Registrations.ResetRegistration");
            
            AddClassConfig("SaveProduct", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Products.SaveProduct");
            AddClassConfig("DeleteProduct", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Products.DeleteProduct");
            AddClassConfig("GetProductInfo", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Products.GetProductInfo");
            AddClassConfig("GetProductList", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Products.GetProductList");   

            AddClassConfig("GetProductTypeList", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.ProductTypes.GetProductTypeList"); 
            AddClassConfig("GetProductTypeInfo", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.ProductTypes.GetProductTypeInfo");
            AddClassConfig("SaveProductType", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.ProductTypes.SaveProductType");

            AddClassConfig("SaveContactUs", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.ContactUs.SaveContactUs");

            AddClassConfig("GetContentList", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Contents.GetContentList");
            AddClassConfig("SaveContent", "OnixBusinessErp.dll:Its.Onix.Erp.Businesses.Contents.SaveContent");
        }  
    } 
}