dotnet run Migrate

dotnet ef migrations add MasterAddKeyAuto \
-o "Its/Onix/Erp/Businesses/Applications/Migrations/MigrationsPgSql" \
--context "OnixBusinessErpApp.OnixErpDbContextPgSql"

dotnet ef database update

dotnet run OperationTest \
--opr=GetMasterList \
--m=Master \
--if=../configs/batch/jsons/Masters/GetMasterList.json

dotnet run OperationTest \
--opr=SaveMaster \
--m=Master \
--if=../configs/batch/jsons/Masters/SaveMaster.json

dotnet run OperationTest \
--opr=IsMasterExist \
--m=Master \
--if=../configs/batch/jsons/Masters/IsMasterExist.json