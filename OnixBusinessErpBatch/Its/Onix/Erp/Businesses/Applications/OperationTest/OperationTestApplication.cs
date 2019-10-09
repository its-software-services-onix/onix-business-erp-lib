using System;
using System.Collections;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Applications;
using Its.Onix.Erp.Businesses.Commons;

using Microsoft.Extensions.Logging;
using NDesk.Options;
using Newtonsoft.Json;

namespace Its.Onix.Erp.Businesses.Applications.OperationTest
{
    public class OperationTestApplication : ConsoleAppBase
    {
        protected override OptionSet PopulateCustomOptionSet(OptionSet options)
        {
            options.Add("opr=", "Business operation name", s => AddArgument("opr", s))
                .Add("if=", "Input file", s => AddArgument("if", s));

            return options;
        }

        protected override int Execute()
        {
            Hashtable args = GetArguments();                        
            ILogger logger = GetLogger();

            string oprName = args["opr"].ToString();
            //string inputFile = args["if"].ToString();

            var opr = (GetListOperation) FactoryBusinessOperation.CreateBusinessOperationObject(oprName);

            QueryRequestParam request = new QueryRequestParam();
            QueryResponseParam response = opr.Apply(request);

            string json = JsonConvert.SerializeObject(response, Formatting.Indented);
            Console.WriteLine(json);

            return 0;
        }
    }
}
