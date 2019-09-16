using System;

using Its.Onix.Core.Utils;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Registrations
{
    public class ResetRegistration : RegistrationOperationBase
    {
        protected override void  ValidateActivation(MRegistration dat, MBarcode bc, string barcode)
        {
            var ctx = GetNoSqlContext();
            var logger = GetLogger();

            if (bc.IsActivated)
            {
                return;
            }

            dat.Status = "FAILED";
            string path = string.Format("registrations/{0}/{1}", dat.Status, barcode);
            ctx.PostData(path, dat);

            string msg = string.Format("Serial number and PIN has not been registered yet [{0}] ", barcode);
            LogUtils.LogInformation(logger, msg);

            throw (new ArgumentException(msg));
        }

        protected override void ValidateRegistration(MRegistration dat)
        {
            if (string.IsNullOrEmpty(dat.SerialNumber) ||
                string.IsNullOrEmpty(dat.Pin))
            {
                throw (new ArgumentException("SerialNumber, PIN must not be null!!!"));
            }
        }

        protected override void PerformRegistrationAction(MRegistration dat,string barcode)
        {
            var ctx = GetNoSqlContext();
            var logger = GetLogger();

            dat.Status = "RESET";
            string path = string.Format("registrations/{0}/{1}", dat.Status, barcode);
            ctx.PostData(path, dat);

            string infoMsg = string.Format("Successfully reset serial number and PIN [{0}]", barcode);
            LogUtils.LogInformation(logger, infoMsg);              
        }    
    }
}
