using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class Convites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_AspNetUsers_ProfessorId",
                table: "Convites");

            migrationBuilder.DropIndex(
                name: "IX_Convites_ProfessorId",
                table: "Convites");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Convites",
                newName: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_TipoQuestaoId",
                table: "Questoes",
                column: "TipoQuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Convites_UsuarioId",
                table: "Convites",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_AspNetUsers_UsuarioId",
                table: "Convites",
                column: "UsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convites_AspNetUsers_UsuarioId",
                table: "Convites");

            migrationBuilder.DropIndex(
                name: "IX_Convites_UsuarioId",
                table: "Convites");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Convites",
                newName: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Convites_ProfessorId",
                table: "Convites",
                column: "ProfessorId",
                unique: true,
                filter: "[ProfessorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Convites_AspNetUsers_ProfessorId",
                table: "Convites",
                column: "ProfessorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
