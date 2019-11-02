using System.ComponentModel.DataAnnotations;
using Its.Onix.Erp.Models.Commons;

namespace Its.Onix.Erp.Models
{
	public class Address : ModelCommonFields
	{
        public int AddressId {get; set;}

        [Required]
        public string AddressNo {get; set;}
        
        public string Road {get; set;}
        public string District {get; set;}
        public string Zip {get; set;}

        public Master Province {get; set;}
    }
}
