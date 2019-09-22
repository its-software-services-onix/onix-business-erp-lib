using Microsoft.EntityFrameworkCore.Migrations;

namespace OnixBusinessErpApp.Its.Onix.Erp.Migrations
{
    public partial class Masters5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Master",
                table: "Master");

            migrationBuilder.RenameTable(
                name: "Master",
                newName: "MasterExs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterExs",
                table: "MasterExs",
                column: "MasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterExs",
                table: "MasterExs");

            migrationBuilder.RenameTable(
                name: "MasterExs",
                newName: "Master");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Master",
                table: "Master",
                column: "MasterId");
        }
    }
}
