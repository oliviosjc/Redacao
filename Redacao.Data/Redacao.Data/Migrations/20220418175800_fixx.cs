using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class fixx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__TemaRedacao__Organizacao",
                table: "TemasRedacao");

            migrationBuilder.DropForeignKey(
                name: "FK__Vestibular__Organizacao",
                table: "Vestibulares");

            migrationBuilder.DropIndex(
                name: "IX_Vestibulares_OrganizacaoId",
                table: "Vestibulares");

            migrationBuilder.DropIndex(
                name: "IX_TemasRedacao_OrganizacaoId",
                table: "TemasRedacao");

            migrationBuilder.DropColumn(
                name: "OrganizacaoId",
                table: "Vestibulares");

            migrationBuilder.DropColumn(
                name: "OrganizacaoId",
                table: "TemasRedacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganizacaoId",
                table: "Vestibulares",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrganizacaoId",
                table: "TemasRedacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vestibulares_OrganizacaoId",
                table: "Vestibulares",
                column: "OrganizacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TemasRedacao_OrganizacaoId",
                table: "TemasRedacao",
                column: "OrganizacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK__TemaRedacao__Organizacao",
                table: "TemasRedacao",
                column: "OrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__Vestibular__Organizacao",
                table: "Vestibulares",
                column: "OrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
