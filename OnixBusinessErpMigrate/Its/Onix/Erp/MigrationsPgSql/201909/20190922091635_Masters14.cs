using Microsoft.EntityFrameworkCore.Migrations;

namespace OnixBusinessErpApp.Its.Onix.Erp.Migrations
{
    public partial class Masters14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Masters",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Masters");
        }
    }
}
