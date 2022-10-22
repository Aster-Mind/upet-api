using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpetApi.Migrations
{
    public partial class MascotasRaza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoAnimal = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    tipoRaza = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Razas");
        }
    }
}
