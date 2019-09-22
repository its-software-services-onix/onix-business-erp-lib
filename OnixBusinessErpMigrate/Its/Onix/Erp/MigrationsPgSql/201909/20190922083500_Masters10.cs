using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnixBusinessErpApp.Its.Onix.Erp.Migrations
{
    public partial class Masters10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MasterExs",
                table: "MasterExs");

            migrationBuilder.RenameTable(
                name: "MasterExs",
                newName: "Masters");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Masters",
                table: "Masters",
                column: "MasterId");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(nullable: true),
                    LastMaintDate = table.Column<DateTime>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CustomerTypeMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Masters_CustomerTypeMasterId",
                        column: x => x.CustomerTypeMasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerTypeMasterId",
                table: "Customers",
                column: "CustomerTypeMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Masters",
                table: "Masters");

            migrationBuilder.RenameTable(
                name: "Masters",
                newName: "MasterExs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MasterExs",
                table: "MasterExs",
                column: "MasterId");
        }
    }
}
