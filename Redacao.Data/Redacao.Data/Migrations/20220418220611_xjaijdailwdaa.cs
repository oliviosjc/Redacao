using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class xjaijdailwdaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "UsuarioOrganizacoes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CriadoEm",
                table: "UsuarioOrganizacoes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsuarioOrganizacoes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificadoEm",
                table: "UsuarioOrganizacoes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioCriadorId",
                table: "UsuarioOrganizacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioOrganizacoes_UsuarioCriadorId",
                table: "UsuarioOrganizacoes",
                column: "UsuarioCriadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioOrganizacoes_AspNetUsers_UsuarioCriadorId",
                table: "UsuarioOrganizacoes",
                column: "UsuarioCriadorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioOrganizacoes_AspNetUsers_UsuarioCriadorId",
                table: "UsuarioOrganizacoes");

            migrationBuilder.DropIndex(
                name: "IX_UsuarioOrganizacoes_UsuarioCriadorId",
                table: "UsuarioOrganizacoes");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "UsuarioOrganizacoes");

            migrationBuilder.DropColumn(
                name: "CriadoEm",
                table: "UsuarioOrganizacoes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsuarioOrganizacoes");

            migrationBuilder.DropColumn(
                name: "ModificadoEm",
                table: "UsuarioOrganizacoes");

            migrationBuilder.DropColumn(
                name: "UsuarioCriadorId",
                table: "UsuarioOrganizacoes");
        }
    }
}
