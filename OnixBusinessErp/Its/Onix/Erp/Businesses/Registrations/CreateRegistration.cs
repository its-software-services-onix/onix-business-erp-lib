using System;

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

            string msgTemplate = string.Format("Serial number and PIN has already been registered [{0}] since [{1}]", "{0}", bc.ActivatedDate);
            string msg = PostData(dat, barcode, "FAILED", msgTemplate);

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
            PostData(dat, barcode, "SUCCESS", "Successfully registered serial number and PIN [{0}]");          
        }
    }
}
