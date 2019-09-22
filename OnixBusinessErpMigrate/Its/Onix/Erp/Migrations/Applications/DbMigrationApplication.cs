using System;
using System.Collections;

using NDesk.Options;
using OnixBusinessErpApp;

using Its.Onix.Core.Utils;
using Its.Onix.Core.Applications;

using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Its.Onix.Erp.Migrations.Applications
{
	public class DbMigrationApplication : ConsoleAppBase
	{        
        protected override OptionSet PopulateCustomOptionSet(OptionSet options)
        {
            options.Clear();
            
            options.Add("host=", "Database server host", s => AddArgument("host", s))
            .Add("port=", "Database server port", s => AddArgument("port", s))
            .Add("user=", "Database user", s => AddArgument("user", s))
            .Add("database=", "Database name", s => AddArgument("database", s))
            .Add("password=", "Database password", s => AddArgument("password", s))
            .Add("provider=", "Database provider", s => AddArgument("provider", s));
            
            return options;
        }
        
        private string GetOptionValue(Hashtable args, string name, string defaultValue)
        {
            if (defaultValue == null)
            {
                defaultValue = "";
            }

            string value = (string) args[name];
            if (string.IsNullOrEmpty(value))
            {
                value = defaultValue;
            }

            return value;
        }

        protected override int Execute()
        {
            ILogger logger = GetLogger();

            Hashtable args = GetArguments();
            string defaultHost = Environment.GetEnvironmentVariable("ONIX_ERP_DB_HOST");

            string host = GetOptionValue(args, "host", defaultHost);
            int port = Int32.Parse(GetOptionValue(args, "port", "5432"));
            string db = GetOptionValue(args, "database", "onix_erp");;
            string uname = GetOptionValue(args, "user", "postgres");
            string passwd = GetOptionValue(args, "password", "");
            string provider = GetOptionValue(args, "provider", "pgsql");

            string msg = "Migrating data : host=[{0}] port=[{1}] db=[{2}] provider=[{3}]...";
            LogUtils.LogInformation(logger, msg, host, port, db, provider);

            OnixErpDbContextPgSql ctx = new OnixErpDbContextPgSql(host, port, db, uname, passwd);
            ctx.Database.Migrate();

            LogUtils.LogInformation(logger, "Migrating done");

            return 0;
        }
    }
}
