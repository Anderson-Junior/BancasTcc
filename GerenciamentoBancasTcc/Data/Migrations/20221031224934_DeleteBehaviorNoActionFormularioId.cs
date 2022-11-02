using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class DeleteBehaviorNoActionFormularioId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Questoes_Formularios_FormularioId",
                table: "Questoes",
                column: "FormularioId",
                principalTable: "Formularios",
                principalColumn: "FormularioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_Questoes_Formularios_FormularioId",
                table: "Questoes",
                column: "FormularioId",
                principalTable: "Formularios",
                principalColumn: "FormularioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
