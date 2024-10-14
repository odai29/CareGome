using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carehome.Migrations
{
    /// <inheritdoc />
    public partial class AlterTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Vist_VisitId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Vist_Animals_AnimalId",
                schema: "dbo",
                table: "Vist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vist",
                schema: "dbo",
                table: "Vist");

            migrationBuilder.RenameTable(
                name: "Vist",
                schema: "dbo",
                newName: "Visit",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Vist_AnimalId",
                schema: "dbo",
                table: "Visit",
                newName: "IX_Visit_AnimalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visit",
                schema: "dbo",
                table: "Visit",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Animals_AnimalId",
                schema: "dbo",
                table: "Visit",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServices_Visit_VisitId",
                schema: "dbo",
                table: "VisitServices",
                column: "VisitId",
                principalSchema: "dbo",
                principalTable: "Visit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Animals_AnimalId",
                schema: "dbo",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Visit_VisitId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visit",
                schema: "dbo",
                table: "Visit");

            migrationBuilder.RenameTable(
                name: "Visit",
                schema: "dbo",
                newName: "Vist",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_Visit_AnimalId",
                schema: "dbo",
                table: "Vist",
                newName: "IX_Vist_AnimalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vist",
                schema: "dbo",
                table: "Vist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServices_Vist_VisitId",
                schema: "dbo",
                table: "VisitServices",
                column: "VisitId",
                principalSchema: "dbo",
                principalTable: "Vist",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vist_Animals_AnimalId",
                schema: "dbo",
                table: "Vist",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
