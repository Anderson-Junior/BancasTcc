using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class DeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
