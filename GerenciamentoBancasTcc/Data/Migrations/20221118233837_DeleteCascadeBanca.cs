using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class DeleteCascadeBanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaQueDeveOcorrerBanca_Bancas_BancaId",
                table: "DiaQueDeveOcorrerBanca");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaQueDeveOcorrerBanca_Bancas_BancaId",
                table: "DiaQueDeveOcorrerBanca",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaQueDeveOcorrerBanca_Bancas_BancaId",
                table: "DiaQueDeveOcorrerBanca");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaQueDeveOcorrerBanca_Bancas_BancaId",
                table: "DiaQueDeveOcorrerBanca",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
