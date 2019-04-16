using Microsoft.EntityFrameworkCore.Migrations;

namespace Poolski.API.Migrations
{
    public partial class AddedCapacityToTripModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Trips",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Trips");
        }
    }
}
