using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OutGetDotNet.Migrations
{
    public partial class Locker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromLockerId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToLockerId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Lockers",
                columns: table => new
                {
                    LockerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lockers", x => x.LockerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_FromLockerId",
                table: "Shipments",
                column: "FromLockerId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_ToLockerId",
                table: "Shipments",
                column: "ToLockerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Lockers_FromLockerId",
                table: "Shipments",
                column: "FromLockerId",
                principalTable: "Lockers",
                principalColumn: "LockerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Lockers_ToLockerId",
                table: "Shipments",
                column: "ToLockerId",
                principalTable: "Lockers",
                principalColumn: "LockerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Lockers_FromLockerId",
                table: "Shipments");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Lockers_ToLockerId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "Lockers");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_FromLockerId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_ToLockerId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "FromLockerId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ToLockerId",
                table: "Shipments");
        }
    }
}
