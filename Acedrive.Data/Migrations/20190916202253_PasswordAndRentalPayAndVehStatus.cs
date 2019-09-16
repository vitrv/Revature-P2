using Microsoft.EntityFrameworkCore.Migrations;

namespace Acedrive.Data.Migrations
{
    public partial class PasswordAndRentalPayAndVehStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RentalCost",
                table: "Rentals",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentalCost",
                table: "Rentals");
        }
    }
}
