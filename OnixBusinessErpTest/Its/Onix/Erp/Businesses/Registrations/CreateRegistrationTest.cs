using System;
using NUnit.Framework;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Businesses.Mocks;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.Registrations
{
	public class GetContentListTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase("192.168.0.1", "9999999999", "ABCDEFGHIJKLM", "This/Is/Faked/Path")]
        public void CreateRegistrationWithCodeNotEmptyTest(string ip, string serial, string pin, string path)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationManipulate<MRegistration>) FactoryBusinessOperation.CreateBusinessOperationObject("CreateRegistration");
            
            MRegistration rg = new MRegistration();
            rg.Pin = pin;
            rg.SerialNumber = serial;
            rg.IP = ip;
            
            try
            {
                opt.Apply(rg);
                Assert.Fail("Exception should be thrown because of barcode not found!!!");
            }
            catch (Exception)
            {
                //Do nothing
            }            
        } 

        [TestCase("192.168.0.1", "9999999999", "", "")]
        [TestCase("192.168.0.1", "", "", "")]
        [TestCase("", "", "", "")]
        [TestCase("", "9999999999", "", "")]
        [TestCase("", "9999999999", "AAAAAAAAAA", "")]
        [TestCase("", "999", "AAAAAAAAAA", "")]
        [TestCase("", "999AAAAA", "AAA", "")]
        [TestCase("IP", "999", "AAA", "")]
        [TestCase("IP", "999", "AA", "")]
        [TestCase("IP", "99", "AAA", "")]        
        [TestCase("IP", "99", "AA", "")]
        public void CreateRegistrationWithEmptyTest(string ip, string serial, string pin, string path)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationManipulate<MRegistration>) FactoryBusinessOperation.CreateBusinessOperationObject("CreateRegistration");
            
            MRegistration rg = new MRegistration();
            rg.Pin = pin;
            rg.SerialNumber = serial;
            rg.IP = ip;
            
            try
            {
                opt.Apply(rg);
                Assert.Fail("Exception should be thrown");
            }
            catch (Exception)
            {
                //Do nothing
            }
        } 

        [TestCase(false, null, "Serial number and PIN not found")]
        [TestCase(true, true, "Serial number and PIN has already been registered")]
        [TestCase(true, false, "")]
        public void CreateRegistrationWithCodeNotFoundTest(bool barcodeFound, bool isActivated, string keyword)
        {
            MockedNoSqlContext ctx = new MockedNoSqlContext();
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            if (barcodeFound)
            {
                MBarcode bc = new MBarcode();
                bc.IsActivated = isActivated;
                ctx.SetReturnObjectByKey(bc);
            }

            var opt = (IBusinessOperationManipulate<MRegistration>) FactoryBusinessOperation.CreateBusinessOperationObject("CreateRegistration");
            
            MRegistration rg = new MRegistration();
            rg.Pin = "9999999999";
            rg.SerialNumber = "ABCDEFGHIJKLM";
            rg.IP = "192.168.0.1";
            
            bool shouldThrow = !barcodeFound || isActivated;

            if (shouldThrow)
            {
                try
                {
                    opt.Apply(rg);
                    Assert.Fail("Exception should be thrown here!!!");
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    bool foundKeyword = msg.Contains(keyword);
                    Assert.AreEqual(true, foundKeyword, "Should get [{0}] error!!!", keyword);
                } 
            }
            else
            {
                //Found barcode and not yet activated
                opt.Apply(rg);

                //Status wrote back to input parameter
                Assert.AreEqual("SUCCESS", rg.Status);
            }       
        }                      
    }
}
