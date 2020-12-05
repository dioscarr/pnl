using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class TaxFormIsFiled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isFiled",
                table: "TaxtForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isFiled",
                table: "TaxtForms");
        }
    }
}
