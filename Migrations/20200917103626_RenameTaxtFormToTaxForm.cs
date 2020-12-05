using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class RenameTaxtFormToTaxForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependent_TaxtForms_TaxFormID",
                table: "Dependent");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentCare_TaxtForms_TaxFormID",
                table: "DependentCare");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormAddress_TaxtForms_TaxFormID",
                table: "TaxFormAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormCriteria_TaxtForms_TaxFormID",
                table: "TaxFormCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormPeople_TaxtForms_TaxFormID",
                table: "TaxFormPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxtForms_FilingStatus_FilingStatusID",
                table: "TaxtForms");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxtForms_Person_PersonID",
                table: "TaxtForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxtForms",
                table: "TaxtForms");

            migrationBuilder.RenameTable(
                name: "TaxtForms",
                newName: "TaxForms");

            migrationBuilder.RenameIndex(
                name: "IX_TaxtForms_PersonID",
                table: "TaxForms",
                newName: "IX_TaxForms_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_TaxtForms_FilingStatusID",
                table: "TaxForms",
                newName: "IX_TaxForms_FilingStatusID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxForms",
                table: "TaxForms",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependent_TaxForms_TaxFormID",
                table: "Dependent",
                column: "TaxFormID",
                principalTable: "TaxForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DependentCare_TaxForms_TaxFormID",
                table: "DependentCare",
                column: "TaxFormID",
                principalTable: "TaxForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxFormAddress_TaxForms_TaxFormID",
                table: "TaxFormAddress",
                column: "TaxFormID",
                principalTable: "TaxForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxFormCriteria_TaxForms_TaxFormID",
                table: "TaxFormCriteria",
                column: "TaxFormID",
                principalTable: "TaxForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxFormPeople_TaxForms_TaxFormID",
                table: "TaxFormPeople",
                column: "TaxFormID",
                principalTable: "TaxForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxForms_FilingStatus_FilingStatusID",
                table: "TaxForms",
                column: "FilingStatusID",
                principalTable: "FilingStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxForms_Person_PersonID",
                table: "TaxForms",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dependent_TaxForms_TaxFormID",
                table: "Dependent");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentCare_TaxForms_TaxFormID",
                table: "DependentCare");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormAddress_TaxForms_TaxFormID",
                table: "TaxFormAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormCriteria_TaxForms_TaxFormID",
                table: "TaxFormCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormPeople_TaxForms_TaxFormID",
                table: "TaxFormPeople");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxForms_FilingStatus_FilingStatusID",
                table: "TaxForms");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxForms_Person_PersonID",
                table: "TaxForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxForms",
                table: "TaxForms");

            migrationBuilder.RenameTable(
                name: "TaxForms",
                newName: "TaxtForms");

            migrationBuilder.RenameIndex(
                name: "IX_TaxForms_PersonID",
                table: "TaxtForms",
                newName: "IX_TaxtForms_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_TaxForms_FilingStatusID",
                table: "TaxtForms",
                newName: "IX_TaxtForms_FilingStatusID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxtForms",
                table: "TaxtForms",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dependent_TaxtForms_TaxFormID",
                table: "Dependent",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DependentCare_TaxtForms_TaxFormID",
                table: "DependentCare",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxFormAddress_TaxtForms_TaxFormID",
                table: "TaxFormAddress",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxFormCriteria_TaxtForms_TaxFormID",
                table: "TaxFormCriteria",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxFormPeople_TaxtForms_TaxFormID",
                table: "TaxFormPeople",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxtForms_FilingStatus_FilingStatusID",
                table: "TaxtForms",
                column: "FilingStatusID",
                principalTable: "FilingStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxtForms_Person_PersonID",
                table: "TaxtForms",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
