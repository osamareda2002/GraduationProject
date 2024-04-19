using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduationProject.Migrations
{
    /// <inheritdoc />
    public partial class relateTraineeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Trainees_TraineeId",
                table: "Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Sports_Trainees_TraineeId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Sports_TraineeId",
                table: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Foods_TraineeId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                table: "Foods");

            migrationBuilder.AddColumn<string>(
                name: "TraineeFoods",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TraineeSports",
                table: "Trainees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TraineeFoods",
                table: "Trainees");

            migrationBuilder.DropColumn(
                name: "TraineeSports",
                table: "Trainees");

            migrationBuilder.AddColumn<int>(
                name: "TraineeId",
                table: "Sports",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TraineeId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_TraineeId",
                table: "Sports",
                column: "TraineeId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_TraineeId",
                table: "Foods",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Trainees_TraineeId",
                table: "Foods",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sports_Trainees_TraineeId",
                table: "Sports",
                column: "TraineeId",
                principalTable: "Trainees",
                principalColumn: "TraineeId");
        }
    }
}
