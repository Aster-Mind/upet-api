using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpetApi.Migrations
{
    public partial class MascotasOk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    raza = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adoptado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascotas");
        }
    }
}
