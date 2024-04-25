using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class updateMealsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Meals");

            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_MealId",
                table: "Foods",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Meals_MealId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_MealId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Foods");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
