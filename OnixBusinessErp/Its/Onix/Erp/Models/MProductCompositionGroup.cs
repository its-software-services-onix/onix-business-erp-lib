using System.Collections.Generic;

using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Models
{
	public class MProductCompositionGroup : BaseModel
	{
        public string PerUnit {get; set;}

        public List<MProductComposition> Compositions {get; set;}

        public MProductCompositionGroup()
        {
            Compositions = new List<MProductComposition>();
        }
    }
}
