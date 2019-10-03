using System;

namespace Its.Onix.Erp.Businesses.Commons
{
	public class TestOperationParam
	{
        public string SaveOprName {get; set;}
        public string IsExistOprName {get; set;}
        public string DeleteOprName {get; set;}
        public string PkFieldName {get; set;}
        public string KeyFieldName {get; set;}
        public string Mode {get; set;}
        public bool CreateDummyRecord {get; set;}
        public bool IsExistSelfIdCheck {get; set;}

        public TestOperationParam()
        {
        }
    }
}