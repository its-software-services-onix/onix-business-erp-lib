dotnet run Migrate --host=130.211.245.2

dotnet ef migrations add MasterAddKeyAuto -o "Its/Onix/Erp/MigrationsPgSql" --context "OnixBusinessErpApp.OnixErpDbContextPgSql"
dotnet ef database update