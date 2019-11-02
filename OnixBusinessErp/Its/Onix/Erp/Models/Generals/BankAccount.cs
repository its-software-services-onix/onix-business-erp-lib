using System.ComponentModel.DataAnnotations;

using Its.Onix.Erp.Models.Commons;

namespace Its.Onix.Erp.Models
{
	public class BankAccount : ModelCommonFields
	{
        public int BankAccountId {get; set;}

        [Required]
        public string AcctNo {get; set;}

        [Required]
        public string AcctName {get; set;}
        public string BranchName {get; set;}

        public Master Bank {get; set;}
    }
}
