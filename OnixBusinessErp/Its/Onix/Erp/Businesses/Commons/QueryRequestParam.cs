using System;
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

        public List<FilterParam> Filters {get; set;}
        public List<OrderByParam> OrderBy {get; set;}
    }
}
