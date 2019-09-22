using System;
using System.Collections.Generic;

using Its.Onix.Erp.Models.Commons;

namespace Its.Onix.Erp.Models.Generals
{
	public class Customer : ModelCommonFields
	{
        public int CustomerId {get; set;}
        public string Code {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}

        public Master CustomerType {get; set;}
        public Master CustomerGroup {get; set;}
        public Master NamePrefix {get; set;}
        public Master CreditTerm {get; set;}

        public List<Address> Addresses { get; set; }
        public List<BankAccount> Accounts { get; set; }
    }
}
