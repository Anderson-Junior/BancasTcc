using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class RenomeandoPropriedadeOrientadorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_AspNetUsers_UsuarioId1",
                table: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_UsuarioId1",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Equipe");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioId",
                table: "Equipe",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrientadorId",
                table: "Equipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_UsuarioId",
                table: "Equipe",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_AspNetUsers_UsuarioId",
                table: "Equipe",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_AspNetUsers_UsuarioId",
                table: "Equipe");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_UsuarioId",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "OrientadorId",
                table: "Equipe");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Equipe",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "Equipe",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_UsuarioId1",
                table: "Equipe",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_AspNetUsers_UsuarioId1",
                table: "Equipe",
                column: "UsuarioId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
