using System.Linq;
using Microsoft.EntityFrameworkCore;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
    public class GetCompanyProfileInfo : GetInfoOperation
    {      
        protected override int GetId(BaseModel dat)
        {
            CompanyProfile m = (CompanyProfile) dat;
            int id = (int) m.CompanyProfileId; 

            return id;
        }

        protected override BaseModel GetObject(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            CompanyProfile m = (CompanyProfile) dat;
            int id = ConvertUtils.NullableToInt(m.CompanyProfileId, 0); 

            var o = ctx.CompanyProfiles
                    .Where(s => s.CompanyProfileId == id)
                    .Include(c => c.CompanyPrefix)
                    .FirstOrDefault();
    
            return o;
        }
    }
}
