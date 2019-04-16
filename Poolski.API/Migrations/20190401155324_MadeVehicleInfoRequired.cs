using Microsoft.EntityFrameworkCore.Migrations;

namespace Poolski.API.Migrations
{
    public partial class MadeVehicleInfoRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vehicles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
