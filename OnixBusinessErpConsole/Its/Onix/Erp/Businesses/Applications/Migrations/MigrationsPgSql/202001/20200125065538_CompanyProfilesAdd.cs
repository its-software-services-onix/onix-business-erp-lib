using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OnixBusinessErpConsole.Its.Onix.Erp.Businesses.Applications.Migrations.MigrationsPgSql
{
    public partial class CompanyProfilesAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyProfiles",
                columns: table => new
                {
                    CompanyProfileId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Key = table.Column<string>(nullable: true),
                    LastMaintDate = table.Column<DateTime>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    OperatorId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    CompanyNameThai = table.Column<string>(nullable: false),
                    CompanyNameEng = table.Column<string>(nullable: false),
                    OperatorNameThai = table.Column<string>(nullable: true),
                    OperatorNameEng = table.Column<string>(nullable: true),
                    AddressThai = table.Column<string>(nullable: true),
                    AddressEng = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    TaxNo = table.Column<string>(nullable: true),
                    RegistrationName = table.Column<string>(nullable: true),
                    RegistrationAddress = table.Column<string>(nullable: true),
                    BuildingName = table.Column<string>(nullable: true),
                    RoomNo = table.Column<string>(nullable: true),
                    FloorNo = table.Column<string>(nullable: true),
                    VillageName = table.Column<string>(nullable: true),
                    HomeNo = table.Column<string>(nullable: true),
                    Moo = table.Column<string>(nullable: true),
                    Soi = table.Column<string>(nullable: true),
                    Road = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    CompanyPrefixMasterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyProfiles", x => x.CompanyProfileId);
                    table.ForeignKey(
                        name: "FK_CompanyProfiles_Masters_CompanyPrefixMasterId",
                        column: x => x.CompanyPrefixMasterId,
                        principalTable: "Masters",
                        principalColumn: "MasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyProfiles_CompanyPrefixMasterId",
                table: "CompanyProfiles",
                column: "CompanyPrefixMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyProfiles");
        }
    }
}
