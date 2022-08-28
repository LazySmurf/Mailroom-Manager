using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mailroom_API.Migrations
{
    public partial class ShipmentUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Airport",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Airport",
                table: "Shipments");
        }
    }
}
