using System;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.Matrices
{
    public class IncreaseAndRetrieve : BusinessOperationBase, IBusinessOperationManipulate<MMatrix>
    {
        public int Apply(MMatrix dat)
        {
            string key = dat.Key;
            string path = string.Format("matrix/{0}", key);

            var ctx = GetNoSqlContext();
            var mtx = ctx.GetObjectByKey<MMatrix>(path);
            if (mtx == null)
            {
                mtx = dat;
            }
            else
            {
                mtx.Value = mtx.Value + dat.Value;
            }
            mtx.LastMaintDate = DateTime.Now;
            ctx.PutData(path, "DEFAULT", mtx);
            return mtx.Value;
        }
    }
}
