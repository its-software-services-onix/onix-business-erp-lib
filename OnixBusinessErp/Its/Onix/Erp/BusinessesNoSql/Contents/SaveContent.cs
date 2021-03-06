using System;

using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.Contents
{
    public class SaveContent : BusinessOperationBase, IBusinessOperationManipulate<MContent>
    {
        public int Apply(MContent dat)
        {
            if (!dat.IsKeyIdentifiable())
            {
                throw (new ArgumentException("Code must not be null!!!"));
            }

            var ctx = GetNoSqlContext();

            //Does not exist then create new one
            string path = string.Format("contents/{0}", dat.Type + "_" + dat.Name);
            //Put again to eliminate the GUI_ID key
            ctx.PutData(path, "", dat);
           
            return 0;
        }
    }
}
