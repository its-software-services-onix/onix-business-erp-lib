using Microsoft.EntityFrameworkCore.Migrations;

namespace OnixBusinessErpMigrate.Its.Onix.Erp.MigrationsPgSql
{
    public partial class ModifyMasterDesc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Masters",
                newName: "ShortDescription");

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Masters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Masters");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Masters",
                newName: "Description");
        }
    }
}
