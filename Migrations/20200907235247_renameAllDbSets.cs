using Microsoft.EntityFrameworkCore.Migrations;

namespace pnl.Migrations
{
    public partial class renameAllDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_People_PersonID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentCares_TaxtForms_TaxFormID",
                table: "DependentCares");

            migrationBuilder.DropForeignKey(
                name: "FK_Dependents_TaxtForms_TaxFormID",
                table: "Dependents");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormCriterias_TaxtForms_TaxFormID",
                table: "TaxFormCriterias");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxtForms_People_PersonID",
                table: "TaxtForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxFormCriterias",
                table: "TaxFormCriterias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DependentCares",
                table: "DependentCares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriteriaOptions",
                table: "CriteriaOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "TaxFormCriterias",
                newName: "TaxFormCriteria");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Dependents",
                newName: "Dependent");

            migrationBuilder.RenameTable(
                name: "DependentCares",
                newName: "DependentCare");

            migrationBuilder.RenameTable(
                name: "CriteriaOptions",
                newName: "CriteriaOption");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Addresse");

            migrationBuilder.RenameIndex(
                name: "IX_TaxFormCriterias_TaxFormID",
                table: "TaxFormCriteria",
                newName: "IX_TaxFormCriteria_TaxFormID");

            migrationBuilder.RenameIndex(
                name: "IX_Dependents_TaxFormID",
                table: "Dependent",
                newName: "IX_Dependent_TaxFormID");

            migrationBuilder.RenameIndex(
                name: "IX_DependentCares_TaxFormID",
                table: "DependentCare",
                newName: "IX_DependentCare_TaxFormID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_PersonID",
                table: "Addresse",
                newName: "IX_Addresse_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxFormCriteria",
                table: "TaxFormCriteria",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependent",
                table: "Dependent",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DependentCare",
                table: "DependentCare",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriteriaOption",
                table: "CriteriaOption",
                column: "id");

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
                name: "FK_TaxFormCriteria_TaxtForms_TaxFormID",
                table: "TaxFormCriteria",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxtForms_Person_PersonID",
                table: "TaxtForms",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresse_Person_PersonID",
                table: "Addresse");

            migrationBuilder.DropForeignKey(
                name: "FK_Dependent_TaxtForms_TaxFormID",
                table: "Dependent");

            migrationBuilder.DropForeignKey(
                name: "FK_DependentCare_TaxtForms_TaxFormID",
                table: "DependentCare");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormCriteria_TaxtForms_TaxFormID",
                table: "TaxFormCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxtForms_Person_PersonID",
                table: "TaxtForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxFormCriteria",
                table: "TaxFormCriteria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DependentCare",
                table: "DependentCare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dependent",
                table: "Dependent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CriteriaOption",
                table: "CriteriaOption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresse",
                table: "Addresse");

            migrationBuilder.RenameTable(
                name: "TaxFormCriteria",
                newName: "TaxFormCriterias");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "People");

            migrationBuilder.RenameTable(
                name: "DependentCare",
                newName: "DependentCares");

            migrationBuilder.RenameTable(
                name: "Dependent",
                newName: "Dependents");

            migrationBuilder.RenameTable(
                name: "CriteriaOption",
                newName: "CriteriaOptions");

            migrationBuilder.RenameTable(
                name: "Addresse",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_TaxFormCriteria_TaxFormID",
                table: "TaxFormCriterias",
                newName: "IX_TaxFormCriterias_TaxFormID");

            migrationBuilder.RenameIndex(
                name: "IX_DependentCare_TaxFormID",
                table: "DependentCares",
                newName: "IX_DependentCares_TaxFormID");

            migrationBuilder.RenameIndex(
                name: "IX_Dependent_TaxFormID",
                table: "Dependents",
                newName: "IX_Dependents_TaxFormID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresse_PersonID",
                table: "Addresses",
                newName: "IX_Addresses_PersonID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxFormCriterias",
                table: "TaxFormCriterias",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DependentCares",
                table: "DependentCares",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dependents",
                table: "Dependents",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CriteriaOptions",
                table: "CriteriaOptions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_People_PersonID",
                table: "Addresses",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DependentCares_TaxtForms_TaxFormID",
                table: "DependentCares",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dependents_TaxtForms_TaxFormID",
                table: "Dependents",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxFormCriterias_TaxtForms_TaxFormID",
                table: "TaxFormCriterias",
                column: "TaxFormID",
                principalTable: "TaxtForms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxtForms_People_PersonID",
                table: "TaxtForms",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
