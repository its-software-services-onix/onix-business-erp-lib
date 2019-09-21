using System;
using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Models
{
	public class MContactUs : BaseModel
	{
        public string Name {get; set;}
        public string Subject {get; set;}
        public string Email {get; set;}
        public string Message {get; set;}
        public string IP {get; set;}
    }
}
