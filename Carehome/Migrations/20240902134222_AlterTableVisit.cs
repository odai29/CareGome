using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carehome.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VisitId",
                schema: "dbo",
                table: "VisitServices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VisitServices_VisitId",
                schema: "dbo",
                table: "VisitServices",
                column: "VisitId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServices_Vist_VisitId",
                schema: "dbo",
                table: "VisitServices",
                column: "VisitId",
                principalSchema: "dbo",
                principalTable: "Vist",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Vist_VisitId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropIndex(
                name: "IX_VisitServices_VisitId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropColumn(
                name: "VisitId",
                schema: "dbo",
                table: "VisitServices");
        }
    }
}
