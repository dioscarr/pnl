using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class Notifications2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaxFormId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TaxFormId",
                table: "Notifications",
                column: "TaxFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_TaxForms_TaxFormId",
                table: "Notifications",
                column: "TaxFormId",
                principalTable: "TaxForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_TaxForms_TaxFormId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TaxFormId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TaxFormId",
                table: "Notifications");
        }
    }
}
