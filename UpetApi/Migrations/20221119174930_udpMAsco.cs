using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UpetApi.Migrations
{
    /// <inheritdoc />
    public partial class udpMAsco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "orgId",
                table: "Mascotas",
                newName: "edad");

            migrationBuilder.AddColumn<string>(
                name: "historia",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "imagen",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefono",
                table: "Organizacions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "color",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "duenoFoto",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "duenoHistoria",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "duenoNombre",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "historia",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "peso",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ubicacion",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "historia",
                table: "Organizacions");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "Organizacions");

            migrationBuilder.DropColumn(
                name: "telefono",
                table: "Organizacions");

            migrationBuilder.DropColumn(
                name: "color",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "duenoFoto",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "duenoHistoria",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "duenoNombre",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "historia",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "peso",
                table: "Mascotas");

            migrationBuilder.DropColumn(
                name: "ubicacion",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "edad",
                table: "Mascotas",
                newName: "orgId");
        }
    }
}
