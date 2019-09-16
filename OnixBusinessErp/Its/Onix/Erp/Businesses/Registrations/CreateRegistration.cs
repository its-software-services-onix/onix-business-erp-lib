using System;

using Its.Onix.Core.Utils;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Registrations
{
    public class CreateRegistration : RegistrationOperationBase
    {
        protected override void  ValidateActivation(MRegistration dat, MBarcode bc, string barcode)
        {
            var ctx = GetNoSqlContext();
            var logger = GetLogger();

            if (!bc.IsActivated)
            {
                return;
            }

            dat.Status = "FAILED";
            string path = string.Format("registrations/{0}/{1}", dat.Status, barcode);
            ctx.PostData(path, dat);

            string msg = string.Format("Serial number and PIN has already been registered [{0}] since [{1}]", barcode, bc.ActivatedDate);
            LogUtils.LogInformation(logger, msg);

            throw (new ArgumentException(msg));
        }

        protected override void ValidateRegistration(MRegistration dat)
        {
            if (string.IsNullOrEmpty(dat.IP) ||
                string.IsNullOrEmpty(dat.SerialNumber) ||
                string.IsNullOrEmpty(dat.Pin))
            {
                throw (new ArgumentException("IP, SerialNumber, PIN must not be null!!!"));
            }
        }

        protected override void PerformRegistrationAction(MRegistration dat,string barcode)
        {
            var ctx = GetNoSqlContext();
            var logger = GetLogger();

            dat.Status = "SUCCESS";
            string path = string.Format("registrations/{0}/{1}", dat.Status, barcode);
            ctx.PostData(path, dat);

            string infoMsg = string.Format("Successfully registered serial number and PIN [{0}]", barcode);
            LogUtils.LogInformation(logger, infoMsg);            
        }
    }
}
