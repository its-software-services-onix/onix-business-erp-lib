dotnet run Migrate

dotnet ef migrations add CompanyProfilesAdd \
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

dotnet run OperationTest \
--opr=SaveCompanyProfile \
--m=CompanyProfile \
--if=../configs/batch/jsons/CompanyProfiles/SaveCompanyProfile.json

dotnet run OperationTest \
--opr=GetCompanyProfileInfo \
--m=CompanyProfile \
--if=../configs/batch/jsons/CompanyProfiles/GetCompanyProfileInfo.json