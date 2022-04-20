using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class xjaijdailwd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Redacao__Organizacao",
                table: "Redacoes");

            migrationBuilder.DropIndex(
                name: "IX_Redacoes_OrganizacaoId",
                table: "Redacoes");

            migrationBuilder.DropColumn(
                name: "OrganizacaoId",
                table: "Redacoes");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "OrganizacaoId",
                table: "Redacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Redacoes_OrganizacaoId",
                table: "Redacoes",
                column: "OrganizacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK__Redacao__Organizacao",
                table: "Redacoes",
                column: "OrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
