using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class RemovendoTabelaEquipe_e_TabelaCursosUsuarios__NovosRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Equipe_EquipeId",
                table: "Alunos");

            migrationBuilder.DropTable(
                name: "CursosUsuarios");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_EquipeId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "EquipeId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "Orientador",
                table: "Bancas",
                newName: "Tema");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Bancas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlunosBancas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    BancaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosBancas", x => new { x.AlunoId, x.BancaId });
                    table.ForeignKey(
                        name: "FK_AlunosBancas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosBancas_Bancas_BancaId",
                        column: x => x.BancaId,
                        principalTable: "Bancas",
                        principalColumn: "BancaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bancas_UsuarioId",
                table: "Bancas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosBancas_BancaId",
                table: "AlunosBancas",
                column: "BancaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bancas_AspNetUsers_UsuarioId",
                table: "Bancas",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bancas_AspNetUsers_UsuarioId",
                table: "Bancas");

            migrationBuilder.DropTable(
                name: "AlunosBancas");

            migrationBuilder.DropIndex(
                name: "IX_Bancas_UsuarioId",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Bancas");

            migrationBuilder.RenameColumn(
                name: "Tema",
                table: "Bancas",
                newName: "Orientador");

            migrationBuilder.AddColumn<int>(
                name: "EquipeId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CursosUsuarios",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursosUsuarios", x => new { x.CursoId, x.UsuarioId });
                    table.ForeignKey(
                        name: "FK_CursosUsuarios_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursosUsuarios_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BancaId = table.Column<int>(type: "int", nullable: true),
                    CursoId = table.Column<int>(type: "int", nullable: true),
                    OrientadorId = table.Column<int>(type: "int", nullable: true),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.EquipeId);
                    table.ForeignKey(
                        name: "FK_Equipe_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipe_Bancas_BancaId",
                        column: x => x.BancaId,
                        principalTable: "Bancas",
                        principalColumn: "BancaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipe_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EquipeId",
                table: "Alunos",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_CursosUsuarios_UsuarioId",
                table: "CursosUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_BancaId",
                table: "Equipe",
                column: "BancaId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_CursoId",
                table: "Equipe",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_UsuarioId",
                table: "Equipe",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Equipe_EquipeId",
                table: "Alunos",
                column: "EquipeId",
                principalTable: "Equipe",
                principalColumn: "EquipeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
