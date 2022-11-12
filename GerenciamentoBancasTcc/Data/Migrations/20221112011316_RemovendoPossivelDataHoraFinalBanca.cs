using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class RemovendoPossivelDataHoraFinalBanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PossivelDataHoraFinal",
                table: "DiaQueDeveOcorrerBanca");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PossivelDataHoraFinal",
                table: "DiaQueDeveOcorrerBanca",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
