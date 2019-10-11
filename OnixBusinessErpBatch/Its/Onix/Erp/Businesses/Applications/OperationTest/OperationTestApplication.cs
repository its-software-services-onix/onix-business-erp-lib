using System;
using System.Collections;
using System.Reflection;
using System.Text.RegularExpressions;

using Its.Onix.Core.Utils;
using Its.Onix.Core.Applications;
using Its.Onix.Erp.Businesses.Applications.OperationTest.Executors;

using Microsoft.Extensions.Logging;
using NDesk.Options;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest
{
    public class OperationTestApplication : ConsoleAppBase
    {
        private ILogger logger = null;
        private Hashtable executorMap = new Hashtable();

        private bool ValidParams(Hashtable args)
        {
            int errCount = 0;
            string[] mandatories = new string[] {"opr:OperationName", "if:JsonFile", "m:ModelName"};

            foreach (var option in mandatories)
            {
                string[] tokens = option.Split(':');
                string opt = tokens[0];
                string param = tokens[1];

                if (!args.Contains(opt))
                {
                    LogUtils.LogError(logger, "Parameter [--{0}=<{1}>] is required!!!", opt, param);   
                    errCount++;                 
                }
            }

            return (errCount <= 0);
        }

        private void InitExecutorMap()
        {
            executorMap["^Save.*$"] = "Its.Onix.Erp.Businesses.Applications.OperationTest.Executors.ManipulateExecutor";
            executorMap["^Delete.*$"] = "Its.Onix.Erp.Businesses.Applications.OperationTest.Executors.ManipulateExecutor";
            executorMap["^Get.*Info$"] = "Its.Onix.Erp.Businesses.Applications.OperationTest.Executors.GetInfoExecutor";
            executorMap["^Get.*List$"] = "Its.Onix.Erp.Businesses.Applications.OperationTest.Executors.GetListExecutor";
            executorMap["^Is.*Exist$"] = "Its.Onix.Erp.Businesses.Applications.OperationTest.Executors.IsExistExecutor";
        }

        protected override OptionSet PopulateCustomOptionSet(OptionSet options)
        {
            options.Add("opr=", "Business operation name", s => AddArgument("opr", s))
                .Add("m=", "Model name", s => AddArgument("m", s))
                .Add("fields=", "Fields overrided", s => AddArgument("fields", s))
                .Add("if=", "Input file", s => AddArgument("if", s));

            return options;
        }

        protected override int Execute()
        {
            InitExecutorMap();

            logger = GetLogger();
            Hashtable args = GetArguments();

            bool isOk = ValidParams(args);
            if (!isOk)
            {
                return 1;
            }
                                       
            string oprName = args["opr"].ToString();            
            foreach (string pattern in executorMap.Keys)
            {
                Match match = Regex.Match(oprName, pattern);
                if (!match.Success)
                {
                    continue;
                }

                string fqdn = (string) executorMap[pattern];
                string json = "";
                
                Assembly asm = Assembly.GetExecutingAssembly();
                IOperationExecutor obj = (IOperationExecutor) asm.CreateInstance(fqdn);
                obj.SetLogger(logger);

                if (fqdn.EndsWith("GetListExecutor"))
                {
                    json = obj.ExecuteGetListOperation(oprName, args);
                }
                else
                {
                    json = obj.ExecuteOperation(oprName, args);
                }

                Console.WriteLine(json);
            }

            return 0;
        }
    }
}
