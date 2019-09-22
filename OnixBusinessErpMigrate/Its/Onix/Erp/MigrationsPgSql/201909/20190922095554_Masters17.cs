using Microsoft.EntityFrameworkCore.Migrations;

namespace OnixBusinessErpApp.Its.Onix.Erp.MigrationsPgSql
{
    public partial class Masters17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Masters",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Customers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "BankAccounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Masters");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Addresses");
        }
    }
}
