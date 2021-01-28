using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class taxFormPeopleisFKupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaxFormPeople_TaxFormID",
                table: "TaxFormPeople");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormPeople_TaxFormID",
                table: "TaxFormPeople",
                column: "TaxFormID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaxFormPeople_TaxFormID",
                table: "TaxFormPeople");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormPeople_TaxFormID",
                table: "TaxFormPeople",
                column: "TaxFormID",
                unique: true);
        }
    }
}
