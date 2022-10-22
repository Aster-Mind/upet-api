using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpetApi.Migrations
{
    public partial class RelacionOngSedes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    pais = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    municipio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    codigoPostal = table.Column<int>(type: "int", nullable: false),
                    colonia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    calle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    numeroExterior = table.Column<int>(type: "int", nullable: false),
                    numeroInterior = table.Column<int>(type: "int", nullable: false),
                    ongId = table.Column<int>(type: "int", nullable: false),
                    ongusersid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sedes_OngUsers_ongusersid",
                        column: x => x.ongusersid,
                        principalTable: "OngUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sedes_ongusersid",
                table: "Sedes",
                column: "ongusersid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sedes");
        }
    }
}
