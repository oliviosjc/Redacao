using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class qqqqqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacaoCorrecaoPerguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRedacao = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EObrigatoria = table.Column<bool>(type: "bit", nullable: false),
                    TipoPergunta = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoCorrecaoPerguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoCorrecaoPerguntas_AspNetUsers_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoRedacaoPerguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRedacao = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EObrigatoria = table.Column<bool>(type: "bit", nullable: false),
                    TipoPergunta = table.Column<int>(type: "int", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoRedacaoPerguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoRedacaoPerguntas_AspNetUsers_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoCorrecaoPerguntaRespostas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AvaliacaoCorrecaoPerguntaId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoCorrecaoPerguntaRespostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoCorrecaoPerguntaRespostas_AspNetUsers_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoCorrecaoPerguntaRespostas_AvaliacaoCorrecaoPerguntas_AvaliacaoCorrecaoPerguntaId",
                        column: x => x.AvaliacaoCorrecaoPerguntaId,
                        principalTable: "AvaliacaoCorrecaoPerguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoRedacaoPerguntaRespostas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AvaliacaoRedacaoPerguntaId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoRedacaoPerguntaRespostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoRedacaoPerguntaRespostas_AspNetUsers_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoRedacaoPerguntaRespostas_AvaliacaoRedacaoPerguntas_AvaliacaoRedacaoPerguntaId",
                        column: x => x.AvaliacaoRedacaoPerguntaId,
                        principalTable: "AvaliacaoRedacaoPerguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoCorrecaoRespostaProfessores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedacaoId = table.Column<int>(type: "int", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AvaliacaoCorrecaoPerguntaRespostaId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoCorrecaoRespostaProfessores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoCorrecaoRespostaProfessores_AspNetUsers_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoCorrecaoRespostaProfessores_AvaliacaoCorrecaoPerguntaRespostas_AvaliacaoCorrecaoPerguntaRespostaId",
                        column: x => x.AvaliacaoCorrecaoPerguntaRespostaId,
                        principalTable: "AvaliacaoCorrecaoPerguntaRespostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacaoCorrecaoRespostaProfessores_Redacoes_RedacaoId",
                        column: x => x.RedacaoId,
                        principalTable: "Redacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacaoRedacaoRespostaAlunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RedacaoId = table.Column<int>(type: "int", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AvaliacaoRedacaoPerguntaRespostaId = table.Column<int>(type: "int", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCriadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaoRedacaoRespostaAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacaoRedacaoRespostaAlunos_AspNetUsers_UsuarioCriadorId",
                        column: x => x.UsuarioCriadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvaliacaoRedacaoRespostaAlunos_AvaliacaoRedacaoPerguntaRespostas_AvaliacaoRedacaoPerguntaRespostaId",
                        column: x => x.AvaliacaoRedacaoPerguntaRespostaId,
                        principalTable: "AvaliacaoRedacaoPerguntaRespostas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacaoRedacaoRespostaAlunos_Redacoes_RedacaoId",
                        column: x => x.RedacaoId,
                        principalTable: "Redacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoCorrecaoPerguntaRespostas_AvaliacaoCorrecaoPerguntaId",
                table: "AvaliacaoCorrecaoPerguntaRespostas",
                column: "AvaliacaoCorrecaoPerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoCorrecaoPerguntaRespostas_UsuarioCriadorId",
                table: "AvaliacaoCorrecaoPerguntaRespostas",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoCorrecaoPerguntas_UsuarioCriadorId",
                table: "AvaliacaoCorrecaoPerguntas",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoCorrecaoRespostaProfessores_AvaliacaoCorrecaoPerguntaRespostaId",
                table: "AvaliacaoCorrecaoRespostaProfessores",
                column: "AvaliacaoCorrecaoPerguntaRespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoCorrecaoRespostaProfessores_RedacaoId",
                table: "AvaliacaoCorrecaoRespostaProfessores",
                column: "RedacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoCorrecaoRespostaProfessores_UsuarioCriadorId",
                table: "AvaliacaoCorrecaoRespostaProfessores",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoRedacaoPerguntaRespostas_AvaliacaoRedacaoPerguntaId",
                table: "AvaliacaoRedacaoPerguntaRespostas",
                column: "AvaliacaoRedacaoPerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoRedacaoPerguntaRespostas_UsuarioCriadorId",
                table: "AvaliacaoRedacaoPerguntaRespostas",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoRedacaoPerguntas_UsuarioCriadorId",
                table: "AvaliacaoRedacaoPerguntas",
                column: "UsuarioCriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoRedacaoRespostaAlunos_AvaliacaoRedacaoPerguntaRespostaId",
                table: "AvaliacaoRedacaoRespostaAlunos",
                column: "AvaliacaoRedacaoPerguntaRespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoRedacaoRespostaAlunos_RedacaoId",
                table: "AvaliacaoRedacaoRespostaAlunos",
                column: "RedacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoRedacaoRespostaAlunos_UsuarioCriadorId",
                table: "AvaliacaoRedacaoRespostaAlunos",
                column: "UsuarioCriadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaoCorrecaoRespostaProfessores");

            migrationBuilder.DropTable(
                name: "AvaliacaoRedacaoRespostaAlunos");

            migrationBuilder.DropTable(
                name: "AvaliacaoCorrecaoPerguntaRespostas");

            migrationBuilder.DropTable(
                name: "AvaliacaoRedacaoPerguntaRespostas");

            migrationBuilder.DropTable(
                name: "AvaliacaoCorrecaoPerguntas");

            migrationBuilder.DropTable(
                name: "AvaliacaoRedacaoPerguntas");
        }
    }
}
