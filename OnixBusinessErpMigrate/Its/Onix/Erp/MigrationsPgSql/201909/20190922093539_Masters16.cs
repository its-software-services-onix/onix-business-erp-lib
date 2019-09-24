using Microsoft.EntityFrameworkCore.Migrations;

namespace OnixBusinessErpApp.Its.Onix.Erp.Migrations
{
    public partial class Masters16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_Masters_BankMasterId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_Customers_CustomerId",
                table: "BankAccount");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount");

            migrationBuilder.RenameTable(
                name: "BankAccount",
                newName: "BankAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccount_CustomerId",
                table: "BankAccounts",
                newName: "IX_BankAccounts_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccount_BankMasterId",
                table: "BankAccounts",
                newName: "IX_BankAccounts_BankMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Masters_BankMasterId",
                table: "BankAccounts",
                column: "BankMasterId",
                principalTable: "Masters",
                principalColumn: "MasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_Customers_CustomerId",
                table: "BankAccounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Masters_BankMasterId",
                table: "BankAccounts");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_Customers_CustomerId",
                table: "BankAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankAccounts",
                table: "BankAccounts");

            migrationBuilder.RenameTable(
                name: "BankAccounts",
                newName: "BankAccount");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccounts_CustomerId",
                table: "BankAccount",
                newName: "IX_BankAccount_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BankAccounts_BankMasterId",
                table: "BankAccount",
                newName: "IX_BankAccount_BankMasterId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankAccount",
                table: "BankAccount",
                column: "BankAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_Masters_BankMasterId",
                table: "BankAccount",
                column: "BankMasterId",
                principalTable: "Masters",
                principalColumn: "MasterId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_Customers_CustomerId",
                table: "BankAccount",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
