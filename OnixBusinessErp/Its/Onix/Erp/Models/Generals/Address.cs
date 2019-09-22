using System;
using Its.Onix.Erp.Models.Commons;

namespace Its.Onix.Erp.Models.Generals
{
	public class Address : ModelCommonFields
	{
        public int AddressId {get; set;}
        public string AddressNo {get; set;}
        public string Road {get; set;}
        public string District {get; set;}
        public string Zip {get; set;}

        public Master Province {get; set;}
    }
}
