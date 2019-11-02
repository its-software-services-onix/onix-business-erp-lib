using System;
using System.Reflection;
using Serilog;
using NDesk.Options;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Applications;
using Its.Onix.Core.Databases;

using Its.Onix.Erp.Services;
using Its.Onix.Erp.Databases;
using Its.Onix.Erp.Businesses.Factories;

namespace Its.Onix.Erp.Businesses.Applications
{
    class Program
    {        
        private static void Init()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddSerilog());    
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();            

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            FactoryApplication.SetLoggerFactory(loggerFactory);

            FactoryBusinessOperation.ClearRegisteredItems();
            FactoryBusinessOperation.RegisterBusinessOperations(BusinessErpOperations.GetInstance().ExportedServicesList());

            string host = Environment.GetEnvironmentVariable("ONIX_ERP_DB_HOST");
            string dbname = Environment.GetEnvironmentVariable("ONIX_ERP_DB_NAME");
            string user = Environment.GetEnvironmentVariable("ONIX_ERP_DB_USER");
            string password = Environment.GetEnvironmentVariable("ONIX_ERP_DB_PASSWORD");
            DbCredential crd = new DbCredential(host, 5432, dbname, user, password, "pgsql");

            OnixErpDbContext ctx = new OnixErpDbContext(crd);
            ctx.SetLoggerFactory(loggerFactory);
            FactoryBusinessOperation.SetDatabaseContext(ctx);
            FactoryBusinessOperation.SetLoggerFactory(loggerFactory);

            Assembly asm = Assembly.GetExecutingAssembly();
            FactoryDbContext.RegisterDbContext(asm, "OnixErpDbContextPgSql", "OnixBusinessErpApp.OnixErpDbContextPgSql");
        }

        static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine("Missing application name!!!");
                return;
            }

            Init();            

            string appName = args[0];
            IApplication app = FactoryApplication.CreateConsoleApplicationObject(appName);    

            OptionSet opt = app.CreateOptionSet();
            opt.Parse(args);

            app.Run();
        }
    }
}
