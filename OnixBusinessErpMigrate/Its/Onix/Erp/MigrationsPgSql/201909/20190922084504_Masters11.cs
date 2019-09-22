using Microsoft.EntityFrameworkCore.Migrations;

namespace OnixBusinessErpApp.Its.Onix.Erp.Migrations
{
    public partial class Masters11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerGroupMasterId",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NamePrefixMasterId",
                table: "Customers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerGroupMasterId",
                table: "Customers",
                column: "CustomerGroupMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NamePrefixMasterId",
                table: "Customers",
                column: "NamePrefixMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Masters_CustomerGroupMasterId",
                table: "Customers",
                column: "CustomerGroupMasterId",
                principalTable: "Masters",
                principalColumn: "MasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Masters_NamePrefixMasterId",
                table: "Customers",
                column: "NamePrefixMasterId",
                principalTable: "Masters",
                principalColumn: "MasterId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Masters_CustomerGroupMasterId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Masters_NamePrefixMasterId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CustomerGroupMasterId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_NamePrefixMasterId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerGroupMasterId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "NamePrefixMasterId",
                table: "Customers");
        }
    }
}
