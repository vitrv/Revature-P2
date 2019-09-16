using Microsoft.EntityFrameworkCore.Migrations;

namespace Acedrive.Data.Migrations
{
    public partial class passwordandVehicleValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserPassword",
                table: "Users",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "VehicleStatus",
                table: "Rentals",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserPassword",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "VehicleStatus",
                table: "Rentals",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(bool));
        }
    }
}
