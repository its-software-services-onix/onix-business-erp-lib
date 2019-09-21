using System;
using Its.Onix.Erp.Models.Commons;

namespace Its.Onix.Erp.Models.Generals
{
	public class Master : ModelCommonFields
	{
        public int MasterId {get; set;}
        public string Code {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}
    }
}
