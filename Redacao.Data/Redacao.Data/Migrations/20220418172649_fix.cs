using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Documento__Organizacao",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_OrganizacaoId",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "AmazonS3Id",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "OrganizacaoId",
                table: "Documentos");

            migrationBuilder.AddColumn<string>(
                name: "NomeInternoAzure",
                table: "Documentos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeOriginal",
                table: "Documentos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeInternoAzure",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "NomeOriginal",
                table: "Documentos");

            migrationBuilder.AddColumn<Guid>(
                name: "AmazonS3Id",
                table: "Documentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Documentos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrganizacaoId",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_OrganizacaoId",
                table: "Documentos",
                column: "OrganizacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK__Documento__Organizacao",
                table: "Documentos",
                column: "OrganizacaoId",
                principalTable: "Organizacoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
