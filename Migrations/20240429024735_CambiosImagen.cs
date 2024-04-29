using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TacoslaEnredada_JRMJSC.Migrations
{
    /// <inheritdoc />
    public partial class CambiosImagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RutaImagen",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RutaImagen",
                table: "Productos");
        }
    }
}
