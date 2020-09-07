using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Data.Migrations
{
    public partial class TaxFormFKsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_People_PrimaryPersonID",
                table: "Dependents");

            migrationBuilder.DropIndex(
                name: "IX_Dependents_PrimaryPersonID",
                table: "Dependents");

            migrationBuilder.DropColumn(
                name: "PrimaryPersonID",
                table: "Dependents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PrimaryPersonID",
                table: "Dependents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_PrimaryPersonID",
                table: "Dependents",
                column: "PrimaryPersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_People_PrimaryPersonID",
                table: "Dependents",
                column: "PrimaryPersonID",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
