using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class oula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Redacao__UsuarioProfessor",
                table: "Redacoes");

            migrationBuilder.DropForeignKey(
                name: "FK__TemaRedacao__Vestibular",
                table: "TemasRedacao");

            migrationBuilder.DropIndex(
                name: "IX_TemasRedacao_VestibularId",
                table: "TemasRedacao");

            migrationBuilder.DropColumn(
                name: "VestibularId",
                table: "TemasRedacao");

            migrationBuilder.RenameColumn(
                name: "UsuarioProfessorId",
                table: "Redacoes",
                newName: "VestibularId");

            migrationBuilder.RenameColumn(
                name: "AvaliacaoProfessorId",
                table: "Redacoes",
                newName: "ProfessorResponsavelId");

            migrationBuilder.RenameIndex(
                name: "IX_Redacoes_UsuarioProfessorId",
                table: "Redacoes",
                newName: "IX_Redacoes_VestibularId");

            migrationBuilder.CreateTable(
                name: "VestibularesTemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemaId = table.Column<int>(type: "int", nullable: false),
                    VestibularId = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VestibularesTemas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VestibularesTemas_AspNetUsers_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VestibularesTemas_TemasRedacao_TemaId",
                        column: x => x.TemaId,
                        principalTable: "TemasRedacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VestibularesTemas_Vestibulares_VestibularId",
                        column: x => x.VestibularId,
                        principalTable: "Vestibulares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Redacoes_ProfessorResponsavelId",
                table: "Redacoes",
                column: "ProfessorResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_VestibularesTemas_TemaId",
                table: "VestibularesTemas",
                column: "TemaId");

            migrationBuilder.CreateIndex(
                name: "IX_VestibularesTemas_UsuarioCriadorId",
                table: "VestibularesTemas",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_VestibularesTemas_VestibularId",
                table: "VestibularesTemas",
                column: "VestibularId");

            migrationBuilder.AddForeignKey(
                name: "FK__Redacao__UsuarioProfessorResponsavel",
                table: "Redacoes",
                column: "ProfessorResponsavelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Redacoes_Vestibulares_VestibularId",
                table: "Redacoes",
                column: "VestibularId",
                principalTable: "Vestibulares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Redacao__UsuarioProfessorResponsavel",
                table: "Redacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Redacoes_Vestibulares_VestibularId",
                table: "Redacoes");

            migrationBuilder.DropTable(
                name: "VestibularesTemas");

            migrationBuilder.DropIndex(
                name: "IX_Redacoes_ProfessorResponsavelId",
                table: "Redacoes");

            migrationBuilder.RenameColumn(
                name: "VestibularId",
                table: "Redacoes",
                newName: "UsuarioProfessorId");

            migrationBuilder.RenameColumn(
                name: "ProfessorResponsavelId",
                table: "Redacoes",
                newName: "AvaliacaoProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Redacoes_VestibularId",
                table: "Redacoes",
                newName: "IX_Redacoes_UsuarioProfessorId");

            migrationBuilder.AddColumn<int>(
                name: "VestibularId",
                table: "TemasRedacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TemasRedacao_VestibularId",
                table: "TemasRedacao",
                column: "VestibularId");

            migrationBuilder.AddForeignKey(
                name: "FK__Redacao__UsuarioProfessor",
                table: "Redacoes",
                column: "UsuarioProfessorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__TemaRedacao__Vestibular",
                table: "TemasRedacao",
                column: "VestibularId",
                principalTable: "Vestibulares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
