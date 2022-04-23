using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class pijaowiddja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Documento__Redacao",
                table: "Documentos");

            migrationBuilder.DropForeignKey(
                name: "FK__Documento__Tema",
                table: "Documentos");

            migrationBuilder.RenameColumn(
                name: "TemaId",
                table: "Documentos",
                newName: "TemaRedacaoId");

            migrationBuilder.RenameColumn(
                name: "RedacaoId",
                table: "Documentos",
                newName: "RedacaoRedacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Documentos_TemaId",
                table: "Documentos",
                newName: "IX_Documentos_TemaRedacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Documentos_RedacaoId",
                table: "Documentos",
                newName: "IX_Documentos_RedacaoRedacaoId");

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDeslikes",
                table: "TemasRedacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeLikes",
                table: "TemasRedacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChaveValor",
                table: "Documentos",
                type: "int",
                maxLength: 8,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_ChaveValor",
                table: "Documentos",
                column: "ChaveValor");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_Tipo",
                table: "Documentos",
                column: "Tipo");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Redacoes_RedacaoRedacaoId",
                table: "Documentos",
                column: "RedacaoRedacaoId",
                principalTable: "Redacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_TemasRedacao_TemaRedacaoId",
                table: "Documentos",
                column: "TemaRedacaoId",
                principalTable: "TemasRedacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Redacoes_RedacaoRedacaoId",
                table: "Documentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_TemasRedacao_TemaRedacaoId",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_ChaveValor",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_Tipo",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "QuantidadeDeslikes",
                table: "TemasRedacao");

            migrationBuilder.DropColumn(
                name: "QuantidadeLikes",
                table: "TemasRedacao");

            migrationBuilder.DropColumn(
                name: "ChaveValor",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Documentos");

            migrationBuilder.RenameColumn(
                name: "TemaRedacaoId",
                table: "Documentos",
                newName: "TemaId");

            migrationBuilder.RenameColumn(
                name: "RedacaoRedacaoId",
                table: "Documentos",
                newName: "RedacaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Documentos_TemaRedacaoId",
                table: "Documentos",
                newName: "IX_Documentos_TemaId");

            migrationBuilder.RenameIndex(
                name: "IX_Documentos_RedacaoRedacaoId",
                table: "Documentos",
                newName: "IX_Documentos_RedacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK__Documento__Redacao",
                table: "Documentos",
                column: "RedacaoId",
                principalTable: "Redacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__Documento__Tema",
                table: "Documentos",
                column: "TemaId",
                principalTable: "TemasRedacao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
