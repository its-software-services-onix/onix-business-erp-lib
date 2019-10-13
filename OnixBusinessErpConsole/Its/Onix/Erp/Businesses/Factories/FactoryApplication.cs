using System;
using System.Collections;
using System.Reflection;

using Microsoft.Extensions.Logging;

using Its.Onix.Core.Applications;

namespace Its.Onix.Erp.Businesses.Factories
{   
    public static class FactoryApplication
    {
        private static ILoggerFactory loggerFactory = null;

        private static Hashtable classMaps = new Hashtable();

        private static void addClassConfig(string apiName, string fqdn)
        {
            classMaps.Add(apiName, fqdn);
        }

        static FactoryApplication()
        {
            initClassMap();
        }

        private static void initClassMap()
        {            
            addClassConfig("OperationTest", "Its.Onix.Erp.Businesses.Applications.OperationTest.OperationTestApplication"); 
            addClassConfig("Migrate", "Its.Onix.Erp.Businesses.Applications.Migrations.DbMigrationApplication"); 
        }  

        public static IApplication CreateConsoleApplicationObject(string name)
        {        
            string className = (string)classMaps[name];
            if (className == null)
            {
                throw new ArgumentNullException(String.Format("Application not found [{0}]", name));
            }

            Assembly asm = Assembly.GetExecutingAssembly();
            IApplication obj = (IApplication)asm.CreateInstance(className);

            if (loggerFactory != null)
            {
                Type t = obj.GetType();
                ILogger logger = loggerFactory.CreateLogger(t);
                obj.SetLogger(logger);
            }
            
            return(obj);
        }

        public static void SetLoggerFactory(ILoggerFactory logFact)
        {
            loggerFactory = logFact;
        }

        public static ILoggerFactory GetLoggerFactory()
        {
            return loggerFactory;
        }  
    }
 
}