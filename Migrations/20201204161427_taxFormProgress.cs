using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class taxFormProgress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) { 

            migrationBuilder.AddColumn<int>(
                name: "Progress",
                table: "TaxForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Progress",
                table: "TaxForms");          
        }
    }
}
