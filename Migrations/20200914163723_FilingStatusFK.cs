using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class FilingStatusFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilingStatusID",
                table: "TaxtForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TaxtForms_FilingStatusID",
                table: "TaxtForms",
                column: "FilingStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxtForms_FilingStatus_FilingStatusID",
                table: "TaxtForms",
                column: "FilingStatusID",
                principalTable: "FilingStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxtForms_FilingStatus_FilingStatusID",
                table: "TaxtForms");

            migrationBuilder.DropIndex(
                name: "IX_TaxtForms_FilingStatusID",
                table: "TaxtForms");

            migrationBuilder.DropColumn(
                name: "FilingStatusID",
                table: "TaxtForms");
        }
    }
}
