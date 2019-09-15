using System;
using System.Collections.Generic;
using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Models
{
    public class MContent : BaseModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, string> Values { get; set; }

        public MContent()
        {
            Values = new Dictionary<string, string>();
        }
        public bool IsKeyIdentifiable()
        {
            bool isError = string.IsNullOrEmpty(Name);
            return !isError;
        }
    }
}
