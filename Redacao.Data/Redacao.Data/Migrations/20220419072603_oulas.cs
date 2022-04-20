using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class oulas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Redacoes_Organizacoes_OrganizacaoOrganizacaoId",
                table: "Redacoes");

            migrationBuilder.DropIndex(
                name: "IX_Redacoes_OrganizacaoOrganizacaoId",
                table: "Redacoes");

            migrationBuilder.DropColumn(
                name: "OrganizacaoOrganizacaoId",
                table: "Redacoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizacaoOrganizacaoId",
                table: "Redacoes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Redacoes_OrganizacaoOrganizacaoId",
                table: "Redacoes",
                column: "OrganizacaoOrganizacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Redacoes_Organizacoes_OrganizacaoOrganizacaoId",
                table: "Redacoes",
                column: "OrganizacaoOrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
