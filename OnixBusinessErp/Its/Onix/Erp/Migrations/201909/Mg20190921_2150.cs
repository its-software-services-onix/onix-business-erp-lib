using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Its.Onix.Erp.Migrations
{
	public class Mg20190921_2150 : Migration
	{
        protected override void Up(MigrationBuilder migrationBuilder)  
        {  
            migrationBuilder.CreateTable(  
                name: "Master",  
                columns: table => new  
                {
                    MasterId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),  
                    Name = table.Column<string>(nullable: true),  
                    Description = table.Column<string>(nullable: true)
                },  
                constraints: table =>  
                {  
                    table.PrimaryKey("Master_PK", x => x.MasterId);  
                });  
        }  
  
        protected override void Down(MigrationBuilder migrationBuilder)  
        {  
            migrationBuilder.DropTable(name: "Master");  
        }       
    }
}
