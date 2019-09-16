using System;

using Microsoft.Extensions.Logging;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;
using Its.Onix.Erp.Utils;
using Its.Onix.Core.Utils;

namespace Its.Onix.Erp.Businesses.Registrations
{
    public class CreateRegistration : BusinessOperationBase, IBusinessOperationManipulate<MRegistration>
    {
        public int Apply(MRegistration dat)
        {
            ILogger logger = GetLogger();

            if (string.IsNullOrEmpty(dat.IP) ||
                string.IsNullOrEmpty(dat.SerialNumber) ||
                string.IsNullOrEmpty(dat.Pin))
            {
                throw (new ArgumentException("IP, SerialNumber, PIN must not be null!!!"));
            }

            string barcode = string.Format("{0}-{1}", dat.SerialNumber, dat.Pin);
            MBarcode bc = null;
            string bcPath = null;
            var ctx = GetNoSqlContext();

            if ((dat.SerialNumber.Length > 3) && (dat.Pin.Length > 3))
            {
                bcPath = BarcodeUtils.BuildBarcodePath("barcodes", dat.SerialNumber, dat.Pin);
                bc = ctx.GetObjectByKey<MBarcode>(bcPath);
            }
            dat.RegistrationDate = DateTime.Now;
            dat.LastMaintDate = DateTime.Now;

            string path = "";
            if (bc == null)
            {
                dat.Status = "NOTFOUND";
                path = string.Format("registrations/{0}/{1}", dat.Status, barcode);
                ctx.PostData(path, dat);

                string msg = string.Format("Serial number and PIN not found [{0}]", barcode);
                LogUtils.LogInformation(logger, msg);

                throw (new ArgumentException(msg));
            }

            if (bc.IsActivated)
            {
                dat.Status = "FAILED";
                path = string.Format("registrations/{0}/{1}", dat.Status, barcode);
                ctx.PostData(path, dat);

                string msg = string.Format("Serial number and PIN has already been registered [{0}] since [{1}]", barcode, bc.ActivatedDate);
                LogUtils.LogInformation(logger, msg);

                throw (new ArgumentException(msg));
            }

            //Update status back to barcode
            bc.IsActivated = true;
            bc.ActivatedDate = DateTime.Now;
            bc.LastMaintDate = DateTime.Now;
            ctx.PutData(bcPath, bc.Key, bc);

            dat.Status = "SUCCESS";
            path = string.Format("registrations/{0}/{1}", dat.Status, barcode);
            ctx.PostData(path, dat);

            string infoMsg = string.Format("Successfully registered serial number and PIN [{0}]", barcode);
            LogUtils.LogInformation(logger, infoMsg);

            return 0;
        }
    }
}
