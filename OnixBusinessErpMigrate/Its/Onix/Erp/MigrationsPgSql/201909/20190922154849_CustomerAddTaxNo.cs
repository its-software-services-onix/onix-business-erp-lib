using Microsoft.EntityFrameworkCore.Migrations;

namespace OnixBusinessErpMigrate.Its.Onix.Erp.MigrationsPgSql
{
    public partial class CustomerAddTaxNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaxNo",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaxNo",
                table: "Customers");
        }
    }
}
