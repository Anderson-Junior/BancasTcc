using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class TesteBanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bancas_Cursos_CursoId",
                table: "Bancas");

            migrationBuilder.DropIndex(
                name: "IX_Bancas_CursoId",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Bancas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Bancas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bancas_CursoId",
                table: "Bancas",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bancas_Cursos_CursoId",
                table: "Bancas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
