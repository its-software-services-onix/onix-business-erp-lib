using System;
using System.Collections.Generic;

using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Models
{
	public class MProductType : BaseModel
	{
        public string Code {get; set;}

        public Dictionary<string, MGenericDescription> Descriptions {get; set;}

        public MProductType()
        {
            Descriptions = new Dictionary<string, MGenericDescription>();
        }

        public bool IsKeyIdentifiable()
        {
            bool isError = string.IsNullOrEmpty(Code);
            return !isError;
        }   
    }
}
