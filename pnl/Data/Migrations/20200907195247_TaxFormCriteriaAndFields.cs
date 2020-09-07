using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Data.Migrations
{
    public partial class TaxFormCriteriaAndFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilingStatus",
                table: "TaxtForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "TaxtForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "People",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TaxFormCriteria",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxFormID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxFormCriteria", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TaxFormCriteria_TaxtForms_TaxFormID",
                        column: x => x.TaxFormID,
                        principalTable: "TaxtForms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxtForms_PersonID",
                table: "TaxtForms",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormCriteria_TaxFormID",
                table: "TaxFormCriteria",
                column: "TaxFormID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxtForms_People_PersonID",
                table: "TaxtForms",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxtForms_People_PersonID",
                table: "TaxtForms");

            migrationBuilder.DropTable(
                name: "TaxFormCriteria");

            migrationBuilder.DropIndex(
                name: "IX_TaxtForms_PersonID",
                table: "TaxtForms");

            migrationBuilder.DropColumn(
                name: "FilingStatus",
                table: "TaxtForms");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "TaxtForms");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "People");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "People");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "People");
        }
    }
}
