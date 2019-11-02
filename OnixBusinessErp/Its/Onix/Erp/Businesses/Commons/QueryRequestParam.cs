using System.Collections.Generic;

namespace Its.Onix.Erp.Businesses.Commons
{
    public class FilterParam
    {
        public string FieldName {get; set;}
        public string Value {get; set;}
        public string Operator {get; set;}        
    }

    public class OrderByParam
    {
        public string FieldName {get; set;}
        public string Order {get; set;} //ASC, DESC
    }

    public class QueryRequestParam
    {
        public int PageNo {get; set;}
        public int PageSize {get; set;}
        public bool ByChunk {get; set;} = true;

        public List<FilterParam> Filters {get; set;} = new List<FilterParam>();
        public List<OrderByParam> OrderBy {get; set;} = new List<OrderByParam>();

        public void AddFilter(string field, string opr, string value)
        {
            var f = new FilterParam() { FieldName = field, Operator = opr, Value = value };
            Filters.Add(f);
        }

        public void AddOrderBy(string field, string order)
        {
            var o = new OrderByParam() { FieldName = field, Order = order };
            OrderBy.Add(o);            
        }
    }
}
