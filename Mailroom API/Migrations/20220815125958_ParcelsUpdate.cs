using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailroom_API.Migrations
{
    public partial class ParcelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_LetterBags_LetterBagBagNo",
                table: "Parcels");

            migrationBuilder.DropForeignKey(
                name: "FK_Parcels_ParcelBags_ParcelBagBagNo",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_LetterBagBagNo",
                table: "Parcels");

            migrationBuilder.DropIndex(
                name: "IX_Parcels_ParcelBagBagNo",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "LetterBagBagNo",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "ParcelBagBagNo",
                table: "Parcels");

            migrationBuilder.AddColumn<bool>(
                name: "IsLetter",
                table: "Parcels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ParcelNos",
                table: "ParcelBags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ParcelList",
                table: "LetterBags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLetter",
                table: "Parcels");

            migrationBuilder.DropColumn(
                name: "ParcelNos",
                table: "ParcelBags");

            migrationBuilder.DropColumn(
                name: "ParcelList",
                table: "LetterBags");

            migrationBuilder.AddColumn<string>(
                name: "LetterBagBagNo",
                table: "Parcels",
                type: "nvarchar(15)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParcelBagBagNo",
                table: "Parcels",
                type: "nvarchar(15)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_LetterBagBagNo",
                table: "Parcels",
                column: "LetterBagBagNo");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ParcelBagBagNo",
                table: "Parcels",
                column: "ParcelBagBagNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_LetterBags_LetterBagBagNo",
                table: "Parcels",
                column: "LetterBagBagNo",
                principalTable: "LetterBags",
                principalColumn: "BagNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Parcels_ParcelBags_ParcelBagBagNo",
                table: "Parcels",
                column: "ParcelBagBagNo",
                principalTable: "ParcelBags",
                principalColumn: "BagNo");
        }
    }
}
