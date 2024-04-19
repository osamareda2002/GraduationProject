using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class intialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyActivity",
                columns: table => new
                {
                    traineeId = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyActivity", x => new { x.traineeId, x.date });
                });

            migrationBuilder.CreateTable(
                name: "FoodReports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    DateOfOccurrence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    foodId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodReports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "SportReports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TraineeId = table.Column<int>(type: "int", nullable: false),
                    DateOfOccurrence = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sportId = table.Column<int>(type: "int", nullable: false),
                    DurationTime = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportReports", x => x.ReportId);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    TraineeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasTools = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    FitnessLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredCalories = table.Column<int>(type: "int", nullable: false),
                    AvailabaleDays = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.TraineeId);
                });

            migrationBuilder.CreateTable(
                name: "FoodEatens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foodId = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<double>(type: "float", nullable: false),
                    DailyActivitydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DailyActivitytraineeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodEatens", x => x.id);
                    table.ForeignKey(
                        name: "FK_FoodEatens_DailyActivity_DailyActivitytraineeId_DailyActivitydate",
                        columns: x => new { x.DailyActivitytraineeId, x.DailyActivitydate },
                        principalTable: "DailyActivity",
                        principalColumns: new[] { "traineeId", "date" });
                });

            migrationBuilder.CreateTable(
                name: "SportDones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sportId = table.Column<int>(type: "int", nullable: false),
                    duration = table.Column<double>(type: "float", nullable: false),
                    DailyActivitydate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DailyActivitytraineeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportDones", x => x.id);
                    table.ForeignKey(
                        name: "FK_SportDones_DailyActivity_DailyActivitytraineeId_DailyActivitydate",
                        columns: x => new { x.DailyActivitytraineeId, x.DailyActivitydate },
                        principalTable: "DailyActivity",
                        principalColumns: new[] { "traineeId", "date" });
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Measure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grams = table.Column<double>(type: "float", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Protein = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: false),
                    Sat_Fat = table.Column<double>(type: "float", nullable: false),
                    Fiber = table.Column<double>(type: "float", nullable: false),
                    Carbs = table.Column<double>(type: "float", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Foods_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "TraineeId");
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaloreisPerKg = table.Column<double>(type: "float", nullable: false),
                    TraineeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                    table.ForeignKey(
                        name: "FK_Sports_Trainees_TraineeId",
                        column: x => x.TraineeId,
                        principalTable: "Trainees",
                        principalColumn: "TraineeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodEatens_DailyActivitytraineeId_DailyActivitydate",
                table: "FoodEatens",
                columns: new[] { "DailyActivitytraineeId", "DailyActivitydate" });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_TraineeId",
                table: "Foods",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_SportDones_DailyActivitytraineeId_DailyActivitydate",
                table: "SportDones",
                columns: new[] { "DailyActivitytraineeId", "DailyActivitydate" });

            migrationBuilder.CreateIndex(
                name: "IX_Sports_TraineeId",
                table: "Sports",
                column: "TraineeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodEatens");

            migrationBuilder.DropTable(
                name: "FoodReports");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "SportDones");

            migrationBuilder.DropTable(
                name: "SportReports");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "DailyActivity");

            migrationBuilder.DropTable(
                name: "Trainees");
        }
    }
}
