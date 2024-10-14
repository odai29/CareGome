using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carehome.Migrations
{
    /// <inheritdoc />
    public partial class EditTableVisitService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VisitServices",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropIndex(
                name: "IX_VisitServices_ServiceId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisitServices",
                schema: "dbo",
                table: "VisitServices",
                columns: new[] { "ServiceId", "VisitId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VisitServices",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "VisitServices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VisitServices",
                schema: "dbo",
                table: "VisitServices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VisitServices_ServiceId",
                schema: "dbo",
                table: "VisitServices",
                column: "ServiceId");
        }
    }
}
