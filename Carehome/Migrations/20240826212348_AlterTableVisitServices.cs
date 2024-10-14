using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carehome.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableVisitServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "dbo",
                table: "VisitServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                schema: "dbo",
                table: "VisitServices",
                type: "decimal(18,3)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
