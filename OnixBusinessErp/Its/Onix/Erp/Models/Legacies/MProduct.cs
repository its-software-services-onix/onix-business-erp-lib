using System;
using System.Collections.Generic;

using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Models
{
	public class MProduct : BaseModel
	{
        public string Code {get; set;}
        public int Rating {get; set;}
        public string ProductType {get; set;}
        public double Price {get; set;}
        public string Unit {get; set;}
        public string Image1Url {get; set;}
        public string Image1LocalPath {get; set;}
        public string Image1StoragePath {get; set;}
        public DateTime LastUpdateDate {get; set;}
        public string NameColor {get; set;}
        public string NameBgColor {get; set;}

        public List<MProductCompositionGroup> CompositionGroups {get; set;}
        public List<MProductPerformance> Performances {get; set;}
        
        public Dictionary<string, MGenericDescription> Descriptions {get; set;}

        public MProduct()
        {
            CompositionGroups = new List<MProductCompositionGroup>();
            Performances = new List<MProductPerformance>();
            Descriptions = new Dictionary<string, MGenericDescription>();
        }

        public bool IsKeyIdentifiable()
        {
            bool isError = string.IsNullOrEmpty(Code);
            return !isError;
        }   
    }
}
