using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd_WebApp_PastilleroAutomatico.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Producto",
                newName: "FechaUltimaModificacion");

            migrationBuilder.AddColumn<string>(
                name: "Marca",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marca",
                table: "Producto");

            migrationBuilder.RenameColumn(
                name: "FechaUltimaModificacion",
                table: "Producto",
                newName: "FechaCreacion");

            migrationBuilder.AddColumn<float>(
                name: "Precio",
                table: "Producto",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
