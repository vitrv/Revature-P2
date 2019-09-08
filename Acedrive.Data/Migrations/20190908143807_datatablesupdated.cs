using Microsoft.EntityFrameworkCore.Migrations;

namespace Acedrive.Data.Migrations
{
    public partial class datatablesupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Payments",
                newName: "PaymentDate");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Rentals",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Rentals");

            migrationBuilder.RenameColumn(
                name: "PaymentDate",
                table: "Payments",
                newName: "UserId");
        }
    }
}
