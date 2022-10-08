using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class VoltandoTabelaConvites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convites",
                columns: table => new
                {
                    ConviteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusConvite = table.Column<int>(type: "int", nullable: false),
                    DataHoraAcao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantidadeAceites = table.Column<int>(type: "int", nullable: false),
                    BancaId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convites", x => x.ConviteId);
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
                name: "IX_Convites_ProfessorId",
                table: "Convites",
                column: "ProfessorId",
                unique: true,
                filter: "[ProfessorId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Convites");
        }
    }
}
