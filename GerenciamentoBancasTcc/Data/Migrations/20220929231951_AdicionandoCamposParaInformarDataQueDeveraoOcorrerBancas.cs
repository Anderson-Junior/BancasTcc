using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class AdicionandoCamposParaInformarDataQueDeveraoOcorrerBancas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convites");

            migrationBuilder.AddColumn<DateTime>(
                name: "PrimeiroDia",
                table: "Bancas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "PrimeiroHorario",
                table: "Bancas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SegundoDia",
                table: "Bancas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "SegundoHorario",
                table: "Bancas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "TerceiroDia",
                table: "Bancas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "TerceiroHorario",
                table: "Bancas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimeiroDia",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "PrimeiroHorario",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "SegundoDia",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "SegundoHorario",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "TerceiroDia",
                table: "Bancas");

            migrationBuilder.DropColumn(
                name: "TerceiroHorario",
                table: "Bancas");

            migrationBuilder.CreateTable(
                name: "Convites",
                columns: table => new
                {
                    ConviteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aceito = table.Column<bool>(type: "bit", nullable: false),
                    BancaId = table.Column<int>(type: "int", nullable: false),
                    CoordenadorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Descrição = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convites", x => x.ConviteId);
                    table.ForeignKey(
                        name: "FK_Convites_AspNetUsers_CoordenadorId",
                        column: x => x.CoordenadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Convites_AspNetUsers_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Convites_Bancas_BancaId",
                        column: x => x.BancaId,
                        principalTable: "Bancas",
                        principalColumn: "BancaId",
                        onDelete: ReferentialAction.Cascade);
                });

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
        }
    }
}
