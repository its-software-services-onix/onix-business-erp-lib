dotnet run Migrate

dotnet ef migrations add MasterAddKeyAuto -o "Its/Onix/Erp/MigrationsPgSql" --context "OnixBusinessErpApp.OnixErpDbContextPgSql"
dotnet ef database update