using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutGetDotNet.Migrations
{
    public partial class AddStateToShipMent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Shipments");
        }
    }
}
