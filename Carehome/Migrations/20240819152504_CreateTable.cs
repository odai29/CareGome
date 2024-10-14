using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Carehome.Migrations
{
    /// <inheritdoc />
    public partial class CreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Animals",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Species = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Users_OwnerUserId",
                        column: x => x.OwnerUserId,
                        principalSchema: "sec",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HealthCare",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TreatmentDescription = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Treatmentprice = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    Totalprice = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCare_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalSchema: "dbo",
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetHotel",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PriceOfDay = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    NumberOfDays = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetHotel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetHotel_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalSchema: "dbo",
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitServices",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitServices_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalSchema: "dbo",
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vist",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VisitingDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vist_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalSchema: "dbo",
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExaminations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    HealthCareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExaminations_HealthCare_HealthCareId",
                        column: x => x.HealthCareId,
                        principalSchema: "dbo",
                        principalTable: "HealthCare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,3)", nullable: false),
                    VisitServicesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_VisitServices_VisitServicesId",
                        column: x => x.VisitServicesId,
                        principalSchema: "dbo",
                        principalTable: "VisitServices",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OwnerUserId",
                schema: "dbo",
                table: "Animals",
                column: "OwnerUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCare_AnimalId",
                schema: "dbo",
                table: "HealthCare",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminations_HealthCareId",
                schema: "dbo",
                table: "MedicalExaminations",
                column: "HealthCareId");

            migrationBuilder.CreateIndex(
                name: "IX_PetHotel_AnimalId",
                schema: "dbo",
                table: "PetHotel",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_VisitServicesId",
                schema: "dbo",
                table: "Services",
                column: "VisitServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitServices_AnimalId",
                schema: "dbo",
                table: "VisitServices",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_Vist_AnimalId",
                schema: "dbo",
                table: "Vist",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalExaminations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PetHotel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vist",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HealthCare",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VisitServices",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Animals",
                schema: "dbo");
        }
    }
}
