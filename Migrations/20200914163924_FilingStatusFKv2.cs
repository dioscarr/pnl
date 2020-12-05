using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class FilingStatusFKv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaxtForms_FilingStatusID",
                table: "TaxtForms");

            migrationBuilder.CreateIndex(
                name: "IX_TaxtForms_FilingStatusID",
                table: "TaxtForms",
                column: "FilingStatusID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TaxtForms_FilingStatusID",
                table: "TaxtForms");

            migrationBuilder.CreateIndex(
                name: "IX_TaxtForms_FilingStatusID",
                table: "TaxtForms",
                column: "FilingStatusID");
        }
    }
}
