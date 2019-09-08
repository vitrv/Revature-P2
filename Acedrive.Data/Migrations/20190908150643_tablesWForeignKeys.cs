using Microsoft.EntityFrameworkCore.Migrations;

namespace Acedrive.Data.Migrations
{
    public partial class tablesWForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Rentals",
                newName: "VehicleRefId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Rentals",
                newName: "UserRefId");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Rentals",
                newName: "LocationRefId");

            migrationBuilder.RenameColumn(
                name: "RentalId",
                table: "Payments",
                newName: "RentalRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_LocationRefId",
                table: "Rentals",
                column: "LocationRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserRefId",
                table: "Rentals",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_VehicleRefId",
                table: "Rentals",
                column: "VehicleRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RentalRefId",
                table: "Payments",
                column: "RentalRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Rentals_RentalRefId",
                table: "Payments",
                column: "RentalRefId",
                principalTable: "Rentals",
                principalColumn: "RentalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Locations_LocationRefId",
                table: "Rentals",
                column: "LocationRefId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Users_UserRefId",
                table: "Rentals",
                column: "UserRefId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Vehicles_VehicleRefId",
                table: "Rentals",
                column: "VehicleRefId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Rentals_RentalRefId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Locations_LocationRefId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Users_UserRefId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Vehicles_VehicleRefId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_LocationRefId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_UserRefId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_VehicleRefId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Payments_RentalRefId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "VehicleRefId",
                table: "Rentals",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "UserRefId",
                table: "Rentals",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "LocationRefId",
                table: "Rentals",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "RentalRefId",
                table: "Payments",
                newName: "RentalId");
        }
    }
}
