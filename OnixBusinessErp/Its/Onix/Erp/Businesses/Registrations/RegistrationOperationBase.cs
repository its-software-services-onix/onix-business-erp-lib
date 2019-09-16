using System;

using Microsoft.Extensions.Logging;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Utils;
using Its.Onix.Core.Utils;

namespace Its.Onix.Erp.Businesses.Registrations
{
    public abstract class RegistrationOperationBase : BusinessOperationBase, IBusinessOperationManipulate<MRegistration>
    {
        protected abstract void ValidateRegistration(MRegistration dat);
        protected abstract void PerformRegistrationAction(MRegistration dat, string barcode);
        protected abstract void ValidateActivation(MRegistration dat, MBarcode bc, string barcode);

        protected string PostData(MRegistration dat, string barcode, string status, string msg)
        {
            var ctx = GetNoSqlContext();
            var logger = GetLogger();

            dat.Status = status;
            string path = string.Format("registrations/{0}/{1}", dat.Status, barcode);
            ctx.PostData(path, dat);

            string infoMsg = string.Format(msg, barcode);
            LogUtils.LogInformation(logger, infoMsg);  

            return infoMsg;
        }

        public int Apply(MRegistration dat)
        {
            ValidateRegistration(dat);

            string barcode = string.Format("{0}-{1}", dat.SerialNumber, dat.Pin);
            MBarcode bc = null;
            string bcPath = null;
            var ctx = GetNoSqlContext();

            if ((dat.SerialNumber.Length > 3) && (dat.Pin.Length > 3))
            {
                bcPath = BarcodeUtils.BuildBarcodePath("barcodes", dat.SerialNumber, dat.Pin);
                bc = ctx.GetObjectByKey<MBarcode>(bcPath);
            }

            if (bc == null)
            {
                string msg = PostData(dat, barcode, "NOTFOUND", "Serial number and PIN not found [{0}]");
                throw (new ArgumentException(msg));
            }

            dat.RegistrationDate = DateTime.Now;
            dat.LastMaintDate = DateTime.Now;            

            ValidateActivation(dat, bc, barcode);
            
            //Update status back to barcode

            bc.IsActivated = true;
            bc.ActivatedDate = DateTime.Now;
            bc.LastMaintDate = DateTime.Now;
            ctx.PutData(bcPath, bc.Key, bc);

            PerformRegistrationAction(dat, barcode);

            return 0;
        }
    }
}