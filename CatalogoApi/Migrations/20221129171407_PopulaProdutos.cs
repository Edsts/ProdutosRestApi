using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogoApi.Migrations
{
    public partial class PopulaProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataDeCadastro,CategoriaId) VALUES('Coca-Cola Diet','Refrigerante de Cola 350 ml',5.45,'cocacola.jpg',50,now(),1)");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataDeCadastro,CategoriaId) VALUES('Lanche de Atum','Lanche de atum com maionese',8.50,'atum.jpg',10,now(),2)");
            migrationBuilder.Sql("INSERT INTO Produtos(Nome,Descricao,Preco,ImagemUrl,Estoque,DataDeCadastro,CategoriaId) VALUES('Pudim 100g','Pudim de leite condensado 100 gramas',6.75,'cocacola.jpg',20,now(),3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
