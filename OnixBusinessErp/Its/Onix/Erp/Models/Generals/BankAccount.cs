using System;
using System.Collections.Generic;

using Its.Onix.Erp.Models.Commons;

namespace Its.Onix.Erp.Models
{
	public class BankAccount : ModelCommonFields
	{
        public int BankAccountId {get; set;}
        public string AcctNo {get; set;}
        public string AcctName {get; set;}
        public string BranchName {get; set;}

        public Master Bank {get; set;}
    }
}
