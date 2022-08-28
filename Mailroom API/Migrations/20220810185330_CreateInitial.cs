using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailroom_API.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    ShipmentNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FlightNo = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    FlightDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.ShipmentNo);
                });

            migrationBuilder.CreateTable(
                name: "LetterBags",
                columns: table => new
                {
                    BagNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LetterCount = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    ShipmentNo = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterBags", x => x.BagNo);
                    table.ForeignKey(
                        name: "FK_LetterBags_Shipments_ShipmentNo",
                        column: x => x.ShipmentNo,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentNo");
                });

            migrationBuilder.CreateTable(
                name: "ParcelBags",
                columns: table => new
                {
                    BagNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    ShipmentNo = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParcelBags", x => x.BagNo);
                    table.ForeignKey(
                        name: "FK_ParcelBags_Shipments_ShipmentNo",
                        column: x => x.ShipmentNo,
                        principalTable: "Shipments",
                        principalColumn: "ShipmentNo");
                });

            migrationBuilder.CreateTable(
                name: "Parcels",
                columns: table => new
                {
                    ParcelNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Recipient = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(20,3)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    LetterBagBagNo = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    ParcelBagBagNo = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parcels", x => x.ParcelNumber);
                    table.ForeignKey(
                        name: "FK_Parcels_LetterBags_LetterBagBagNo",
                        column: x => x.LetterBagBagNo,
                        principalTable: "LetterBags",
                        principalColumn: "BagNo");
                    table.ForeignKey(
                        name: "FK_Parcels_ParcelBags_ParcelBagBagNo",
                        column: x => x.ParcelBagBagNo,
                        principalTable: "ParcelBags",
                        principalColumn: "BagNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LetterBags_ShipmentNo",
                table: "LetterBags",
                column: "ShipmentNo");

            migrationBuilder.CreateIndex(
                name: "IX_ParcelBags_ShipmentNo",
                table: "ParcelBags",
                column: "ShipmentNo");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_LetterBagBagNo",
                table: "Parcels",
                column: "LetterBagBagNo");

            migrationBuilder.CreateIndex(
                name: "IX_Parcels_ParcelBagBagNo",
                table: "Parcels",
                column: "ParcelBagBagNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parcels");

            migrationBuilder.DropTable(
                name: "LetterBags");

            migrationBuilder.DropTable(
                name: "ParcelBags");

            migrationBuilder.DropTable(
                name: "Shipments");
        }
    }
}
