using System;
using System.Linq;

using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Businesses.Commons
{
    public class QueryResponseParam
    {
        public int TotalRecord {get; set;}
        public int TotalPage {get; set;}
        public int RecordCount {get; set;}

        public IQueryable<BaseModel> Results {get; set;}
    }
}
