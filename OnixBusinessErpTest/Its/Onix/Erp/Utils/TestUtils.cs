using System;

using Its.Onix.Core.Commons.Model;

namespace Its.Onix.Erp.Utils
{
	public static class TestUtils
	{        
        public static object GetPropertyValue(BaseModel model, string propName)
        {
            var prop = model.GetType().GetProperty(propName);
            var value = prop.GetValue(model);

            return value;
        }

        public static void SetPropertyValue(BaseModel model, string propName, object value)
        {
            var prop = model.GetType().GetProperty(propName);
            prop.SetValue(model, value);
        }

        public static void PopulateDummyPropValues(BaseModel model)
        {
            PopulateDummyPropValues(model, "");
        }

        public static void PopulateDummyPropValues(BaseModel model, string exceptField)
        {
            var props = model.GetType().GetProperties();
            foreach (var prop in props)
            {
                if (prop.Name.Equals(exceptField))
                {
                    continue;
                }

                object oldValue = null;

                if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                {
                    oldValue = 99999;
                }
                else if (prop.PropertyType == typeof(double))
                {
                    oldValue = 69696.99;
                }
                else if (prop.PropertyType == typeof(string))
                {
                    oldValue = RandomUtils.RandomStringNum(20);
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
            }
        }
    }
}