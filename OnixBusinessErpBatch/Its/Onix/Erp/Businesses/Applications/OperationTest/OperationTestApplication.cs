using System;
using System.Collections;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Applications;
using Its.Onix.Core.Utils;
using Its.Onix.Erp.Businesses.Commons;

using Microsoft.Extensions.Logging;
using NDesk.Options;
using Newtonsoft.Json;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest
{
    public class OperationTestApplication : ConsoleAppBase
    {
        private ILogger logger = null;

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

        protected override OptionSet PopulateCustomOptionSet(OptionSet options)
        {
            options.Add("opr=", "Business operation name", s => AddArgument("opr", s))
                .Add("m=", "Model name", s => AddArgument("m", s))
                .Add("if=", "Input file", s => AddArgument("if", s));

            return options;
        }

        protected override int Execute()
        {
            logger = GetLogger();
            Hashtable args = GetArguments();

            bool isOk = ValidParams(args);
            if (!isOk)
            {
                return 1;
            }
                                       
            string oprName = args["opr"].ToString();
            string inputFile = args["if"].ToString();

            var opr = (GetListOperation) FactoryBusinessOperation.CreateBusinessOperationObject(oprName);

            QueryRequestParam request = new QueryRequestParam();
            QueryResponseParam response = opr.Apply(request);

            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            Console.WriteLine(json);

            return 0;
        }
    }
}
