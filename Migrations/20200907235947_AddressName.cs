using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class AddressName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresse_Person_PersonID",
                table: "Addresse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresse",
                table: "Addresse");

            migrationBuilder.RenameTable(
                name: "Addresse",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Addresse_PersonID",
                table: "Address",
                newName: "IX_Address_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonID",
                table: "Address",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonID",
                table: "Address");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresse");

            migrationBuilder.RenameIndex(
                name: "IX_Address_PersonID",
                table: "Addresse",
                newName: "IX_Addresse_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresse",
                table: "Addresse",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresse_Person_PersonID",
                table: "Addresse",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
