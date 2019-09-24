using System;
using System.Reflection;

using Serilog;
using NDesk.Options;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Its.Onix.Core.Factories;
using Its.Onix.Core.Applications;

namespace OnixBusinessErpApp
{
    class Program
    {
        private static void RegisterApplications()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            FactoryApplicationContext.RegisterApplication(asm, "Migrate", "Its.Onix.Erp.Migrations.Applications.DbMigrationApplication");

            FactoryDbContext.RegisterDbContext(asm, "OnixErpDbContextPgSql", "OnixBusinessErpApp.OnixErpDbContextPgSql");
        }

        static void Main(string[] args)
        {
            RegisterApplications();
            
            string appName = args[0];

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddSerilog());
        
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            FactoryDbContext.SetLoggerFactory(loggerFactory);

            FactoryApplicationContext.SetLoggerFactory(loggerFactory);
            IApplication app = FactoryApplicationContext.CreateApplicationObject(appName);    

            OptionSet opt = app.CreateOptionSet();
            opt.Parse(args);

            app.Run();
        }
    }
}
