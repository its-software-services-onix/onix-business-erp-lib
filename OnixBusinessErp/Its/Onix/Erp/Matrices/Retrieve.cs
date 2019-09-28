using System;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.Matrices
{
    public class Retrieve : BusinessOperationBase, IBusinessOperationManipulate<MMatrix>
    {
        public int Apply(MMatrix dat)
        {
            DateTime currentDate = DateTime.Now;
            dat.LastMaintDate = currentDate;

            string path = string.Format("matrix/{0}", dat.Key);

            var ctx = GetNoSqlContext();
            var mtx = ctx.GetObjectByKey<MMatrix>(path);
            if (mtx == null)
            {
                return 0;
            }
            return mtx.Value;
        }
    }
}
