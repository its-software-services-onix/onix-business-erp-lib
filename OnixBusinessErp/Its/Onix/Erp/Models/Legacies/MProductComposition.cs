using System;
using System.Collections.Generic;

using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Models
{
	public class MProductComposition : BaseModel
	{
        public string Code {get; set;}
        public double Quantity {get; set;}
        public string Unit {get; set;}

        public Dictionary<string, MGenericDescription> Descriptions {get; set;}

        public MProductComposition()
        {
            Descriptions = new Dictionary<string, MGenericDescription>();
        }
    }
}
