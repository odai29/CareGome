using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carehome.Migrations
{
    /// <inheritdoc />
    public partial class modifyVisitServices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Animals_AnimalId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Visit_VisitId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropIndex(
                name: "IX_VisitServices_AnimalId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.DropColumn(
                name: "Date",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                schema: "dbo",
                table: "VisitServices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServices_Visit_VisitId",
                schema: "dbo",
                table: "VisitServices",
                column: "VisitId",
                principalSchema: "dbo",
                principalTable: "Visit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VisitServices_Visit_VisitId",
                schema: "dbo",
                table: "VisitServices");

            migrationBuilder.AlterColumn<int>(
                name: "VisitId",
                schema: "dbo",
                table: "VisitServices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                schema: "dbo",
                table: "VisitServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "dbo",
                table: "VisitServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_VisitServices_AnimalId",
                schema: "dbo",
                table: "VisitServices",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_VisitServices_Animals_AnimalId",
                schema: "dbo",
                table: "VisitServices",
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
    }
}
