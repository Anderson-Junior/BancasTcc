using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class NovosRelaciomentosTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Filiais_FilialId",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Bancas",
                newName: "DataHora");

            migrationBuilder.AlterColumn<int>(
                name: "BancaId",
                table: "Equipe",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Equipe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Equipe",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Equipe",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Bancas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Bancas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Orientador",
                table: "Bancas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sala",
                table: "Bancas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "Alunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_CursoId",
                table: "Equipe",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_UsuarioId1",
                table: "Equipe",
                column: "UsuarioId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Filiais_FilialId",
                table: "Cursos",
                column: "FilialId",
                principalTable: "Filiais",
                principalColumn: "FilialId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_AspNetUsers_UsuarioId1",
                table: "Equipe",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Cursos_CursoId",
                table: "Equipe",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bancas_Cursos_CursoId",
                table: "Bancas");

            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Filiais_FilialId",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_AspNetUsers_UsuarioId1",
                table: "Equipe");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Cursos_CursoId",
                table: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_CursoId",
                table: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_UsuarioId1",
                table: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Bancas_CursoId",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "Orientador",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "Sala",
                table: "Bancas");

            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Bancas",
                newName: "Data");

            migrationBuilder.AlterColumn<int>(
                name: "BancaId",
                table: "Equipe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipeId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Filiais_FilialId",
                table: "Cursos",
                column: "FilialId",
                principalTable: "Filiais",
                principalColumn: "FilialId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
