using System;

using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Registrations
{
    public class ResetRegistration : RegistrationOperationBase
    {
        protected override void  ValidateActivation(MRegistration dat, MBarcode bc, string barcode)
        {
            if (bc.IsActivated)
            {
                return;
            }

            string msg = PostData(dat, barcode, "FAILED", "Serial number and PIN has not been registered yet [{0}]");

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
            PostData(dat, barcode, "RESET", "Successfully reset serial number and PIN [{0}]");
        }    
    }
}
