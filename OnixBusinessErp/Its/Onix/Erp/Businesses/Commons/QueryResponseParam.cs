using System.Collections.Generic;

using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Businesses.Commons
{
    public class QueryResponseParam
    {
        public int TotalRecord {get; set;}
        public int TotalPage {get; set;}
        public int RecordCount {get; set;}
        public int PageNo {get; set;}

        public List<BaseModel> Results {get; set;}
    }
}
