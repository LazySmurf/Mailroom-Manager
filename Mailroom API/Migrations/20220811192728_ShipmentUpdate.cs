using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailroom_API.Migrations
{
    public partial class ShipmentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LetterBags_Shipments_ShipmentNo",
                table: "LetterBags");

            migrationBuilder.DropForeignKey(
                name: "FK_ParcelBags_Shipments_ShipmentNo",
                table: "ParcelBags");

            migrationBuilder.DropIndex(
                name: "IX_ParcelBags_ShipmentNo",
                table: "ParcelBags");

            migrationBuilder.DropIndex(
                name: "IX_LetterBags_ShipmentNo",
                table: "LetterBags");

            migrationBuilder.DropColumn(
                name: "ShipmentNo",
                table: "ParcelBags");

            migrationBuilder.DropColumn(
                name: "ShipmentNo",
                table: "LetterBags");

            migrationBuilder.AddColumn<string>(
                name: "BagList",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFinalized",
                table: "Shipments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BagList",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "IsFinalized",
                table: "Shipments");

            migrationBuilder.AddColumn<string>(
                name: "ShipmentNo",
                table: "ParcelBags",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipmentNo",
                table: "LetterBags",
                type: "nvarchar(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParcelBags_ShipmentNo",
                table: "ParcelBags",
                column: "ShipmentNo");

            migrationBuilder.CreateIndex(
                name: "IX_LetterBags_ShipmentNo",
                table: "LetterBags",
                column: "ShipmentNo");

            migrationBuilder.AddForeignKey(
                name: "FK_LetterBags_Shipments_ShipmentNo",
                table: "LetterBags",
                column: "ShipmentNo",
                principalTable: "Shipments",
                principalColumn: "ShipmentNo");

            migrationBuilder.AddForeignKey(
                name: "FK_ParcelBags_Shipments_ShipmentNo",
                table: "ParcelBags",
                column: "ShipmentNo",
                principalTable: "Shipments",
                principalColumn: "ShipmentNo");
        }
    }
}
