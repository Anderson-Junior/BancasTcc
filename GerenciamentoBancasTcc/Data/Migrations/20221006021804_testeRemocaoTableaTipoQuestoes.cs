using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class testeRemocaoTableaTipoQuestoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites");

            migrationBuilder.DropTable(
                name: "TipoQuestoes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Questoes");

            migrationBuilder.AlterColumn<int>(
                name: "FormularioId",
                table: "Questoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QtdPrimeiroDia",
                table: "Convites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtdSegundoDia",
                table: "Convites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtdTerceiroDia",
                table: "Convites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QtdProfBanca",
                table: "Bancas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites");

            migrationBuilder.DropColumn(
                name: "QtdPrimeiroDia",
                table: "Convites");

            migrationBuilder.DropColumn(
                name: "QtdSegundoDia",
                table: "Convites");

            migrationBuilder.DropColumn(
                name: "QtdTerceiroDia",
                table: "Convites");

            migrationBuilder.DropColumn(
                name: "QtdProfBanca",
                table: "Bancas");

            migrationBuilder.AlterColumn<int>(
                name: "FormularioId",
                table: "Questoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Questoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TipoQuestoes",
                columns: table => new
                {
                    TipoQuestaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoQuestoes", x => x.TipoQuestaoId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
