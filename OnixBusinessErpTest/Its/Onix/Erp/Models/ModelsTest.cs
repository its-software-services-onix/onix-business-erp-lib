using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

using NUnit.Framework;

using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Models
{
	public class ModelsTest
	{
        private List<Type> models = null;

        [SetUp]
        public void Setup()
        {
            Type type = typeof(Master);
            Assembly asm = Assembly.GetAssembly(type);

            models = asm.GetTypes()
                    .Where(t => t.Namespace.Equals("Its.Onix.Erp.Models"))
                    .ToList();
        }

        [TestCase]
        public void ModelPopulatePropertiesTest()
        {
            foreach (var t in models)
            {
                var model = (BaseModel) Activator.CreateInstance(t);

                var props = model.GetType().GetProperties();                

                foreach(var prop in props) 
                {
                    object oldValue = null;

                    if (prop.PropertyType == typeof(int))
                    {
                        oldValue = 99999;                        
                    }
                    else if (prop.PropertyType == typeof(double))
                    {
                        oldValue = 69696.99;
                    }
                    else if (prop.PropertyType == typeof(string))
                    {
                        oldValue = "THIS IS DUMMY STRING";
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                    {
                        oldValue = DateTime.Now;
                    }
                    else if (prop.PropertyType == typeof(bool))
                    {
                        oldValue = false;
                    }

                    prop.SetValue(model, oldValue);
                    var newValue = prop.GetValue(model);

                    Assert.AreEqual(oldValue, newValue, "Property value should be the same for set and get !!!");
                }   
            }         
        }
    }
}
