using System;
using System.IO;
using System.Collections;

using Newtonsoft.Json;

using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Models;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest.Executors
{
    public abstract class BaseOperationExecutor : IOperationExecutor
    {
        protected abstract object Apply(string oprName, BaseModel m);

        private BaseModel CreateModel(dynamic o, Type t)
        {
            return null;
        }

        public string ExecuteOperation(string oprName, Hashtable args)
        {
            string model = args["m"].ToString();

            string jsonFile = args["if"].ToString();            
            string content = File.ReadAllText(jsonFile);

            BaseModel m = null;
            if (model.Equals("Master"))
            {
                m = JsonConvert.DeserializeObject<Master>(content);
            }
/*
            m.MasterId = 304; //Comment MasterId will add
            m.Code = "IN3";
            m.Name = "Individual XXX";
            m.Type = 1;
            m.LastMaintDate = DateTime.Now;
 */
            object o = Apply(oprName, m);

            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            return json;
        }
    }
}