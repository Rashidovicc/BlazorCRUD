using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Game.Web.Migrations
{
    public partial class seccondMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "FirstName", "Gmail", "LastName", "Login", "Password", "PhoneNumber" },
                values: new object[] { 1, "Botirali", "muhammmadibnabdurashid@gmail.com", "Rahmonberdiyev", "botir1202", "botir1202", "+998901313126" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
