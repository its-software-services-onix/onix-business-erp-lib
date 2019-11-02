using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnixBusinessErpMigrate.Its.Onix.Erp.MigrationsPgSql
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masters",
                columns: table => new
                {
                    MasterId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(nullable: true),
                    LastMaintDate = table.Column<DateTime>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    OperatorId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LongDescription = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masters", x => x.MasterId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(nullable: true),
                    LastMaintDate = table.Column<DateTime>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    OperatorId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: false),
                    CustomerTypeMasterId = table.Column<int>(nullable: true),
                    CustomerGroupMasterId = table.Column<int>(nullable: true),
                    NamePrefixMasterId = table.Column<int>(nullable: true),
                    CreditTermMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Masters_CreditTermMasterId",
                        column: x => x.CreditTermMasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Masters_CustomerGroupMasterId",
                        column: x => x.CustomerGroupMasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Masters_CustomerTypeMasterId",
                        column: x => x.CustomerTypeMasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Masters_NamePrefixMasterId",
                        column: x => x.NamePrefixMasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(nullable: true),
                    LastMaintDate = table.Column<DateTime>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    OperatorId = table.Column<int>(nullable: false),
                    AddressNo = table.Column<string>(nullable: false),
                    Road = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    ProvinceMasterId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Masters_ProvinceMasterId",
                        column: x => x.ProvinceMasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    BankAccountId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(nullable: true),
                    LastMaintDate = table.Column<DateTime>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    OperatorId = table.Column<int>(nullable: false),
                    AcctNo = table.Column<string>(nullable: false),
                    AcctName = table.Column<string>(nullable: false),
                    BranchName = table.Column<string>(nullable: true),
                    BankMasterId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.BankAccountId);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Masters_BankMasterId",
                        column: x => x.BankMasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProvinceMasterId",
                table: "Addresses",
                column: "ProvinceMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_BankMasterId",
                table: "BankAccounts",
                column: "BankMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_CustomerId",
                table: "BankAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreditTermMasterId",
                table: "Customers",
                column: "CreditTermMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerGroupMasterId",
                table: "Customers",
                column: "CustomerGroupMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeMasterId",
                table: "Customers",
                column: "CustomerTypeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NamePrefixMasterId",
                table: "Customers",
                column: "NamePrefixMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Masters_Code",
                table: "Masters",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Masters");
        }
    }
}
