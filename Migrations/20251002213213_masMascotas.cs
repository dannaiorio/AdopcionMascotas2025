using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdopcionMascotas.Migrations
{
    /// <inheritdoc />
    public partial class masMascotas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Especie",
                table: "Mascotas",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Mascotas",
                columns: new[] { "Id", "Descripcion", "Edad", "Especie", "Estado", "Imagen", "Nombre" },
                values: new object[,]
                {
                    { 1, "Perro juguetón y sociable", 3, 1, 0, "/images/placeholder.jpg", "Firulais" },
                    { 2, "Perra tranquila y cariñosa", 5, 1, 0, "/images/placeholder.jpg", "Luna" },
                    { 3, "Gato curioso y activo", 2, 2, 0, "/images/placeholder.jpg", "Michi" },
                    { 4, "Gata blanca muy mimosa", 4, 2, 1, "/images/placeholder.jpg", "Nieve" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mascotas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mascotas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mascotas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mascotas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Especie",
                table: "Mascotas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
