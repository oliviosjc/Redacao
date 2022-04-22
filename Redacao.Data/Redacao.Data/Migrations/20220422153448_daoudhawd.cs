using Microsoft.EntityFrameworkCore.Migrations;

namespace Redacao.Data.Migrations
{
    public partial class daoudhawd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resposta",
                table: "Sugestoes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resposta",
                table: "Sugestoes");
        }
    }
}
