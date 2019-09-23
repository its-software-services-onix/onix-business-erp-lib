using System;

using Its.Onix.Erp.Utils;
using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.Barcodes
{
    public class CreateBarcode : BusinessOperationBase, IBusinessOperationGetInfo<MBarcode>
    {
        public MBarcode Apply(MBarcode dat)
        {
            MBarcode bc = new MBarcode();
            bc.BatchNo = dat.BatchNo;
            bc.Url = dat.Url;
            bc.Product = dat.Product;
            bc.GeneratedDate = DateTime.Now;
            bc.IsActivated = false;
            bc.Path = dat.Path;

            bc.CompanyWebSite = dat.CompanyWebSite;
            bc.Barcode = dat.Barcode;
            bc.Product = dat.Product;

            if (IsMigration(dat))
            {
                bc.SerialNumber = dat.SerialNumber;
                bc.Pin = dat.Pin;
                bc.PayloadUrl = dat.PayloadUrl;
            }
            else
            {
                bc.SerialNumber = RandomUtils.RandomStringNum(10);
                bc.Pin = RandomUtils.RandomStringNum(10);
                bc.PayloadUrl = string.Format("{0}/verification/{1}/{2}/{3}", bc.Url, bc.Path, bc.SerialNumber, bc.Pin);
            }

            string path = BarcodeUtils.BuildBarcodePath("barcodes", bc.SerialNumber, bc.Pin);

            var ctx = GetNoSqlContext();
            ctx.PostData(path, bc);

            return bc;
        }

        private bool IsMigration(MBarcode dat)
        {
            if (!string.IsNullOrEmpty(dat.SerialNumber)
                && !string.IsNullOrEmpty(dat.Pin)
                && !string.IsNullOrEmpty(dat.PayloadUrl))
            {
                return true;
            }
            return false;
        }
    }
}
