using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Its.Onix.Erp.Models.Commons;

namespace Its.Onix.Erp.Models
{
	public class Customer : ModelCommonFields
	{
        public int? CustomerId {get; set;}

        [Required]
        public string Code {get; set;}

        [Required]
        public string Name {get; set;}
        public string LastName {get; set;}

        [Required]
        public string TaxNo {get; set;}

        public Master CustomerType {get; set;}
        public Master CustomerGroup {get; set;}
        public Master NamePrefix {get; set;}
        public Master CreditTerm {get; set;}

        public List<Address> Addresses { get; set; }
        public List<BankAccount> Accounts { get; set; }
    }
}
