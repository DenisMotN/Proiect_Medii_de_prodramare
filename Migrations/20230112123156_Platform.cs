using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_de_prodramare.Migrations
{
    public partial class Platform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlatformID",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlatformID",
                table: "Game",
                column: "PlatformID");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Platform_PlatformID",
                table: "Game",
                column: "PlatformID",
                principalTable: "Platform",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Platform_PlatformID",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Game_PlatformID",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "PlatformID",
                table: "Game");
        }
    }
}
