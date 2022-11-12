using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class AlterandoPk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaQueDeveOcorrerBanca",
                table: "DiaQueDeveOcorrerBanca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaQueDeveOcorrerBanca",
                table: "DiaQueDeveOcorrerBanca",
                column: "DiaQueDeveOcorrerBancaId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaQueDeveOcorrerBanca_BancaId",
                table: "DiaQueDeveOcorrerBanca",
                column: "BancaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaQueDeveOcorrerBanca",
                table: "DiaQueDeveOcorrerBanca");

            migrationBuilder.DropIndex(
                name: "IX_DiaQueDeveOcorrerBanca_BancaId",
                table: "DiaQueDeveOcorrerBanca");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaQueDeveOcorrerBanca",
                table: "DiaQueDeveOcorrerBanca",
                column: "BancaId");
        }
    }
}
