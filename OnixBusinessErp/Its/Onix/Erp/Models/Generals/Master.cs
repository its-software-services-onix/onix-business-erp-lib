using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Its.Onix.Erp.Models.Commons;

namespace Its.Onix.Erp.Models
{
	public class Master : ModelCommonFields
	{
        public int MasterId {get; set;} //No need to assign value to get auto generate

        [Required]
        public string Code {get; set;}

        [Required]
        public string Name {get; set;}

        public string LongDescription {get; set;}
        public string ShortDescription {get; set;}

        [Required]
        public int Type {get; set;}
    }
}
