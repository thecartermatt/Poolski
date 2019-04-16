using Microsoft.EntityFrameworkCore.Migrations;

namespace Poolski.API.Migrations
{
    public partial class AddedHostUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HostUserId",
                table: "Trips",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_HostUserId",
                table: "Trips",
                column: "HostUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Users_HostUserId",
                table: "Trips",
                column: "HostUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Users_HostUserId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_HostUserId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "HostUserId",
                table: "Trips");
        }
    }
}
