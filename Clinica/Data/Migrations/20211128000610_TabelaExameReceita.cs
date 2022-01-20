using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Data.Migrations
{
    public partial class TabelaExameReceita : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Receita",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receita_MedicoId",
                table: "Receita",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Medicos_MedicoId",
                table: "Receita",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receita_Medicos_MedicoId",
                table: "Receita");

            migrationBuilder.DropIndex(
                name: "IX_Receita_MedicoId",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Receita");
        }
    }
}
