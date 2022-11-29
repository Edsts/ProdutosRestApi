using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoApi.Migrations
{
    public partial class PopulaCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Lanches', 'lanches.jpg')");
            migrationBuilder.Sql("INSERT INTO Categorias(Nome, ImagemUrl) VALUES('Sobremesa', 'sobremesas.jpg')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
        }
    }
}
