using System.Linq;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Utils;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
    public class SaveCompanyProfile : ManipulationOperation
    {        
        protected override BaseModel Execute(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            CompanyProfile m = (CompanyProfile) dat;

            if ((m.CompanyPrefix != null) && (m.CompanyPrefix.MasterId != null))
            {
                int? id = m.CompanyPrefix.MasterId;
                var o = ctx.Masters
                    .Where(s => s.MasterId == id)
                    .FirstOrDefault();

                m.CompanyPrefix = o;                 
            }
            
            if (ConvertUtils.NullableToInt(m.CompanyProfileId, 0) <= 0)
            {
                m.CompanyProfileId = null;
                ctx.CompanyProfiles.Add(m);
            }
            else
            {
                ctx.CompanyProfiles.Update(m);
            }

            ctx.SaveChanges();
            return m;
        }
    }
}
