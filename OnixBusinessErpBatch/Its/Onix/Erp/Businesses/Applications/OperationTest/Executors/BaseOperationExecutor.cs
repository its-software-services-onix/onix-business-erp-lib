using System;
using System.IO;
using System.Reflection;
using System.Collections;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Its.Onix.Core.Utils;
using Its.Onix.Core.Commons.Model;
using Its.Onix.Erp.Models;
using Its.Onix.Core.Factories;
using Its.Onix.Erp.Businesses.Commons;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest.Executors
{
    public abstract class BaseOperationExecutor : IOperationExecutor
    {
        protected ILogger logger;

        protected abstract object Apply(string oprName, BaseModel m);

        public void SetLogger(ILogger logger)
        {
            this.logger = logger;
        }

        private BaseModel CreateModel(dynamic o, Type t)
        {
            return null;
        }

        private void OverridedFields(BaseModel model, Hashtable args)
        {
            if (!args.Contains("fields"))
            {
                return;
            }

            string fields = (string) args["fields"];
            string[] tokens = fields.Split(';');

            foreach (string token in tokens)
            {
                string[] f = token.Split('=');
                string field = f[0];
                string value = f[1];

                PopulateField(model, field, value);
            }
        }

        private void PopulateField(BaseModel model, string field, string value)
        {
            var prop = model.GetType().GetProperty(field);
            if (prop == null)
            {
                LogUtils.LogWarning(logger, "Property [{0}] not found!!!", field);
                return;
            }

            object newValue = null;

            if (prop.PropertyType == typeof(int))
            {
                newValue = Int32.Parse(value);
            }
            else if (prop.PropertyType == typeof(double))
            {
                newValue = Double.Parse(value);
            }
            else if (prop.PropertyType == typeof(string))
            {
                newValue = value;
            }
            else if (prop.PropertyType == typeof(DateTime))
            {
                newValue = DateTime.Now;
            }
            else if (prop.PropertyType == typeof(bool))
            {
                newValue = Boolean.Parse(value);
            }

            prop.SetValue(model, newValue);
        }

        public string ExecuteOperation(string oprName, Hashtable args)
        {
            string model = args["m"].ToString();
            string fqdn = string.Format("Its.Onix.Erp.Models.{0}", model);

            Assembly asm = typeof(Master).Assembly;
            Type type = asm.GetType(fqdn);

            string jsonFile = args["if"].ToString();
            string content = File.ReadAllText(jsonFile);

            BaseModel m = (BaseModel) JsonConvert.DeserializeObject(content, type);
            OverridedFields(m, args);

            object o = Apply(oprName, m);

            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            return json;
        }

        public string ExecuteGetListOperation(string oprName, Hashtable args)
        {
            var opr = (GetListOperation) FactoryBusinessOperation.CreateBusinessOperationObject(oprName);

            QueryRequestParam request = new QueryRequestParam(); //Should get from JSON instead
            QueryResponseParam response = opr.Apply(request);

            string json = JsonConvert.SerializeObject(response, Formatting.Indented);

            return json;
        }
    }
}