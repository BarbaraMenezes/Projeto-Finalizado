using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    public partial class AtualizacaoEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "tb_estoque");

            migrationBuilder.RenameColumn(
                name: "DTEntrada",
                table: "tb_estoque",
                newName: "Data_de_Entrada");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tb_estoque",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_estoque",
                table: "tb_estoque",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_estoque",
                table: "tb_estoque");

            migrationBuilder.RenameTable(
                name: "tb_estoque",
                newName: "Produtos");

            migrationBuilder.RenameColumn(
                name: "Data_de_Entrada",
                table: "Produtos",
                newName: "DTEntrada");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Produtos",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");
        }
    }
}
