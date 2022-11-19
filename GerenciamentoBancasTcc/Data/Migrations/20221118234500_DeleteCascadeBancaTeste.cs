using Microsoft.EntityFrameworkCore.Migrations;

namespace GerenciamentoBancasTcc.Data.Migrations
{
    public partial class DeleteCascadeBancaTeste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaQueDeveOcorrerBanca_Convites_ConviteId",
                table: "DiaQueDeveOcorrerBanca");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaQueDeveOcorrerBanca_Convites_ConviteId",
                table: "DiaQueDeveOcorrerBanca",
                column: "ConviteId",
                principalTable: "Convites",
                principalColumn: "ConviteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaQueDeveOcorrerBanca_Convites_ConviteId",
                table: "DiaQueDeveOcorrerBanca");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaQueDeveOcorrerBanca_Convites_ConviteId",
                table: "DiaQueDeveOcorrerBanca",
                column: "ConviteId",
                principalTable: "Convites",
                principalColumn: "ConviteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
