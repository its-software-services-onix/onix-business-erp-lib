using System;
using System.Collections.Generic;

using Its.Onix.Core.Commons.Table;
using Its.Onix.Erp.Models;
using Its.Onix.Core.Business;

namespace Its.Onix.Erp.Businesses.Contents
{
    public class GetContentList : BusinessOperationBase, IBusinessOperationQuery<MContent>
    {
        public IEnumerable<MContent> Apply(MContent dat, CTable param)
        {
            //Parameter "dat" can be use for create the filter in the future
            var ctx = GetNoSqlContext();
            var path = "contents";
            IEnumerable<MContent> contents = ctx.GetObjectList<MContent>(path);

            return contents;
        }
    }
}
