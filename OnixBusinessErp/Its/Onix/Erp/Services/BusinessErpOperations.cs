using System.Reflection;

namespace Its.Onix.Erp.Services
{   
    public class BusinessErpOperations : BusinessErpBase
    {
        private static BusinessErpOperations instance = new BusinessErpOperations();

        public static BusinessErpOperations GetInstance()
        {
            return instance;
        }
        
        private BusinessErpOperations()
        {
            InitClassMap();
        }

        private void InitClassMap()
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
            AddClassConfig(asm, "RetrieveMetric", "Its.Onix.Erp.Businesses.Matrices.Retrieve");
            AddClassConfig(asm, "IncreaseAndRetrieveMetric", "Its.Onix.Erp.Businesses.Matrices.IncreaseAndRetrieve");

            //SQL
            AddClassConfig(asm, "SaveMaster", "Its.Onix.Erp.Businesses.Masters.SaveMaster");
            AddClassConfig(asm, "DeleteMaster", "Its.Onix.Erp.Businesses.Masters.DeleteMaster");
            AddClassConfig(asm, "IsMasterExist", "Its.Onix.Erp.Businesses.Masters.IsMasterExist");

        }  
    } 
}