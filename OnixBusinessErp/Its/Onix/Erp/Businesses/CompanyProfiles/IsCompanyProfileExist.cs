using System;
using System.Linq;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
    public class IsCompanyProfileExist : IsExistOperation
    {      
        protected override int GetId(BaseModel dat)
        {
            CompanyProfile m = (CompanyProfile) dat;
            int id = ConvertUtils.NullableToInt(m.CompanyProfileId, 0); 

            return id;
        }

        protected override BaseModel GetObject(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            CompanyProfile m = (CompanyProfile) dat;
            string key = m.Code;   

            var o = ctx.CompanyProfiles
                    .Where(s => s.Code.Equals(key))
                    .FirstOrDefault();
    
            return o;
        }
    }
}
