using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class NovosRelacionamentosConvites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Instituicoes_InstituicaoId",
                table: "Filiais");

            migrationBuilder.DropTable(
                name: "ConvitesUsuarios");

            migrationBuilder.DropTable(
                name: "DiasDisponiveis");

            migrationBuilder.AddColumn<int>(
                name: "BancaId",
                table: "Convites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CoordenadorId",
                table: "Convites",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfessorId",
                table: "Convites",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Convites_BancaId",
                table: "Convites",
                column: "BancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Convites_CoordenadorId",
                table: "Convites",
                column: "CoordenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Convites_ProfessorId",
                table: "Convites",
                column: "ProfessorId",
                unique: true,
                filter: "[ProfessorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_AspNetUsers_CoordenadorId",
                table: "Convites",
                column: "CoordenadorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_AspNetUsers_ProfessorId",
                table: "Convites",
                column: "ProfessorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites",
                column: "BancaId",
                principalTable: "Bancas",
                principalColumn: "BancaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Instituicoes_InstituicaoId",
                table: "Filiais",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "InstituicaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_AspNetUsers_CoordenadorId",
                table: "Convites");

            migrationBuilder.DropForeignKey(
                name: "FK_Convites_AspNetUsers_ProfessorId",
                table: "Convites");

            migrationBuilder.DropForeignKey(
                name: "FK_Convites_Bancas_BancaId",
                table: "Convites");

            migrationBuilder.DropForeignKey(
                name: "FK_Filiais_Instituicoes_InstituicaoId",
                table: "Filiais");

            migrationBuilder.DropIndex(
                name: "IX_Convites_BancaId",
                table: "Convites");

            migrationBuilder.DropIndex(
                name: "IX_Convites_CoordenadorId",
                table: "Convites");

            migrationBuilder.DropIndex(
                name: "IX_Convites_ProfessorId",
                table: "Convites");

            migrationBuilder.DropColumn(
                name: "BancaId",
                table: "Convites");

            migrationBuilder.DropColumn(
                name: "CoordenadorId",
                table: "Convites");

            migrationBuilder.DropColumn(
                name: "ProfessorId",
                table: "Convites");

            migrationBuilder.CreateTable(
                name: "ConvitesUsuarios",
                columns: table => new
                {
                    ConviteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvitesUsuarios", x => new { x.ConviteId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_ConvitesUsuarios_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConvitesUsuarios_Convites_ConviteId",
                        column: x => x.ConviteId,
                        principalTable: "Convites",
                        principalColumn: "ConviteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiasDisponiveis",
                columns: table => new
                {
                    DiasDisponiveisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaDisponivel = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiasDisponiveis", x => x.DiasDisponiveisId);
                    table.ForeignKey(
                        name: "FK_DiasDisponiveis_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConvitesUsuarios_UsuarioId",
                table: "ConvitesUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DiasDisponiveis_UsuarioId",
                table: "DiasDisponiveis",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filiais_Instituicoes_InstituicaoId",
                table: "Filiais",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "InstituicaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
