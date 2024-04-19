using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class changeFoodTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Carbs",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Fat",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Fiber",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Grams",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Protein",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "Sat_Fat",
                table: "Foods");

            migrationBuilder.RenameColumn(
                name: "Measure",
                table: "Foods",
                newName: "Serving");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Serving",
                table: "Foods",
                newName: "Measure");

            migrationBuilder.AddColumn<double>(
                name: "Carbs",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Fat",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Fiber",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Grams",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Protein",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Sat_Fat",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
