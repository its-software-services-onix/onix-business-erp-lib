using System;
using NUnit.Framework;

using Moq;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Business;
using Its.Onix.Core.NoSQL;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.Barcodes
{
	public class CreateBarcodeTest
	{
        [SetUp]
        public void Setup()
        {
            FactoryBusinessOperationUtils.LoadBusinessOperations();
        }

        [TestCase]
        public void CreateBarcodeWithRandomStringTest()
        {
            INoSqlContext ctx = new Mock<INoSqlContext>().Object;
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationGetInfo<MBarcode>) FactoryBusinessOperation.CreateBusinessOperationObject("CreateBarcode");
            MBarcode bc = new MBarcode();
            bc.Url = "http://this_is_fake_url";
            bc.Path = "this/is/faked/path";

            MBarcode barcode1 = opt.Apply(bc);
            string playLoad1 = string.Format("{0}/verification/{1}/{2}/{3}", bc.Url, bc.Path, barcode1.SerialNumber, barcode1.Pin);

            MBarcode barcode2 = opt.Apply(bc);
            string playLoad2 = string.Format("{0}/verification/{1}/{2}/{3}", bc.Url, bc.Path, barcode2.SerialNumber, barcode2.Pin);

            Assert.AreNotEqual(barcode1.SerialNumber, barcode2.SerialNumber, "SerialNumber must be different!!!");
            Assert.AreNotEqual(barcode1.Pin, barcode2.Pin, "PIN must be different!!!");

            Assert.AreEqual(playLoad1, barcode1.PayloadUrl, "Payload URL incorrect!!!");
            Assert.AreEqual(playLoad2, barcode2.PayloadUrl, "Payload URL incorrect!!!");            
        } 

        [TestCase("SERIAL", "PIN", "PAYLOAD/URL")]
        public void CreateBarcodeWithMigrationModeTest(string serial, string pin, string payload)
        {
            INoSqlContext ctx = new Mock<INoSqlContext>().Object;
            FactoryBusinessOperation.SetNoSqlContext(ctx);

            var opt = (IBusinessOperationGetInfo<MBarcode>) FactoryBusinessOperation.CreateBusinessOperationObject("CreateBarcode");
            MBarcode bc = new MBarcode();
            bc.SerialNumber = serial;
            bc.Pin = pin;
            bc.PayloadUrl = payload;

            MBarcode barcode1 = opt.Apply(bc);

            Assert.AreEqual(serial, barcode1.SerialNumber, "SerialNumber must be the same!!!");
            Assert.AreEqual(pin, barcode1.Pin, "Pin must be the same!!!");
            Assert.AreEqual(payload, barcode1.PayloadUrl, "Payload URL must be the same!!!");
        }         
    }
}
