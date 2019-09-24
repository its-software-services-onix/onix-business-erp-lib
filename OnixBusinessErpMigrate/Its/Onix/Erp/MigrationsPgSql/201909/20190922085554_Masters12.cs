using Microsoft.EntityFrameworkCore.Migrations;

namespace OnixBusinessErpApp.Its.Onix.Erp.Migrations
{
    public partial class Masters12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditTermMasterId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreditTermMasterId",
                table: "Customers",
                column: "CreditTermMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Masters_CreditTermMasterId",
                table: "Customers",
                column: "CreditTermMasterId",
                principalTable: "Masters",
                principalColumn: "MasterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Masters_CreditTermMasterId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CreditTermMasterId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreditTermMasterId",
                table: "Customers");
        }
    }
}
