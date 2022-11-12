using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class NovaEstruturaConvites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "DiasQueDevemOcorrerBanca",
                table: "Bancas");

            migrationBuilder.CreateTable(
                name: "DiaQueDeveOcorrerBanca",
                columns: table => new
                {
                    BancaId = table.Column<int>(type: "int", nullable: false),
                    DiaQueDeveOcorrerBancaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PossivelDataHoraInicial = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PossivelDataHoraFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConviteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaQueDeveOcorrerBanca", x => x.BancaId);
                    table.ForeignKey(
                        name: "FK_DiaQueDeveOcorrerBanca_Bancas_BancaId",
                        column: x => x.BancaId,
                        principalTable: "Bancas",
                        principalColumn: "BancaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DiaQueDeveOcorrerBanca_Convites_ConviteId",
                        column: x => x.ConviteId,
                        principalTable: "Convites",
                        principalColumn: "ConviteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaQueDeveOcorrerBanca_ConviteId",
                table: "DiaQueDeveOcorrerBanca",
                column: "ConviteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaQueDeveOcorrerBanca");

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

            migrationBuilder.AddColumn<string>(
                name: "DiasQueDevemOcorrerBanca",
                table: "Bancas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
