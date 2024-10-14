using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carehome.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTablesHealtMedicalVisitServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalExaminations_HealthCare_HealthCareId",
                schema: "dbo",
                table: "MedicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_VisitServices_VisitServicesId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_VisitServicesId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_MedicalExaminations_HealthCareId",
                schema: "dbo",
                table: "MedicalExaminations");

            migrationBuilder.DropColumn(
                name: "VisitServicesId",
                schema: "dbo",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "HealthCareId",
                schema: "dbo",
                table: "MedicalExaminations");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "dbo",
                table: "MedicalExaminations",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Totalprice",
                schema: "dbo",
                table: "HealthCare",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                schema: "dbo",
                table: "VisitServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicalExaminationId",
                schema: "dbo",
                table: "HealthCare",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VisitServices_ServiceId",
                schema: "dbo",
                table: "VisitServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCare_MedicalExaminationId",
                schema: "dbo",
                table: "HealthCare",
                column: "MedicalExaminationId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthCare_MedicalExaminations_MedicalExaminationId",
                schema: "dbo",
                table: "HealthCare",
                column: "MedicalExaminationId",
                principalSchema: "dbo",
                principalTable: "MedicalExaminations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServices_Services_ServiceId",
                schema: "dbo",
                table: "VisitServices",
                column: "ServiceId",
                principalSchema: "dbo",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthCare_MedicalExaminations_MedicalExaminationId",
                schema: "dbo",
                table: "HealthCare");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Services_ServiceId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropIndex(
                name: "IX_VisitServices_ServiceId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropIndex(
                name: "IX_HealthCare_MedicalExaminationId",
                schema: "dbo",
                table: "HealthCare");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropColumn(
                name: "MedicalExaminationId",
                schema: "dbo",
                table: "HealthCare");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "dbo",
                table: "MedicalExaminations",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "dbo",
                table: "HealthCare",
                newName: "Totalprice");

            migrationBuilder.AddColumn<int>(
                name: "VisitServicesId",
                schema: "dbo",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HealthCareId",
                schema: "dbo",
                table: "MedicalExaminations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_VisitServicesId",
                schema: "dbo",
                table: "Services",
                column: "VisitServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminations_HealthCareId",
                schema: "dbo",
                table: "MedicalExaminations",
                column: "HealthCareId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalExaminations_HealthCare_HealthCareId",
                schema: "dbo",
                table: "MedicalExaminations",
                column: "HealthCareId",
                principalSchema: "dbo",
                principalTable: "HealthCare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_VisitServices_VisitServicesId",
                schema: "dbo",
                table: "Services",
                column: "VisitServicesId",
                principalSchema: "dbo",
                principalTable: "VisitServices",
                principalColumn: "Id");
        }
    }
}
