using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Businesses.Commons;
using Its.Onix.Erp.Models;
using Its.Onix.Erp.Databases;

namespace Its.Onix.Erp.Businesses.CompanyProfiles
{
    public class DeleteCompanyProfile : ManipulationOperation
    {        
        protected override BaseModel Execute(BaseModel dat)
        {
            OnixErpDbContext ctx = (OnixErpDbContext) context;

            CompanyProfile m = (CompanyProfile) dat;
            ctx.CompanyProfiles.Remove(m);
            ctx.SaveChanges();

            return m;
        }
    }
}
