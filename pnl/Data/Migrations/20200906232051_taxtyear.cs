using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Data.Migrations
{
    public partial class taxtyear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxtYear",
                table: "TaxtForms",
                newName: "TaxYear");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxYear",
                table: "TaxtForms",
                newName: "TaxtYear");
        }
    }
}
