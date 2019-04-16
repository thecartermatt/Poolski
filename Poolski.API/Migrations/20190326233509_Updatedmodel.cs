using Microsoft.EntityFrameworkCore.Migrations;

namespace Poolski.API.Migrations
{
    public partial class Updatedmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Trips_TripId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_TripId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_TripId",
                table: "Users",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Trips_TripId",
                table: "Users",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
