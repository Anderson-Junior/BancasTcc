using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class AddColunaQtdAceitesTabelaDiaQueDeveOcorrerBanca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeAceites",
                table: "Convites");

            migrationBuilder.AddColumn<int>(
                name: "QtdAceites",
                table: "DiaQueDeveOcorrerBanca",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QtdAceites",
                table: "DiaQueDeveOcorrerBanca");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeAceites",
                table: "Convites",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
