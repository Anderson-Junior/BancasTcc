using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class ExcluirBancaEArquivosJunto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_Bancas_BancaId",
                table: "Arquivos");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_Bancas_BancaId",
                table: "Arquivos",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_Bancas_BancaId",
                table: "Arquivos");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_Bancas_BancaId",
                table: "Arquivos",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
