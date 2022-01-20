using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Data.Migrations
{
    public partial class tabelaAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgendaId",
                table: "Medicos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Agendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataDisponivel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_AgendaId",
                table: "Medicos",
                column: "AgendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicos_Agendas_AgendaId",
                table: "Medicos",
                column: "AgendaId",
                principalTable: "Agendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicos_Agendas_AgendaId",
                table: "Medicos");

            migrationBuilder.DropTable(
                name: "Agendas");

            migrationBuilder.DropIndex(
                name: "IX_Medicos_AgendaId",
                table: "Medicos");

            migrationBuilder.DropColumn(
                name: "AgendaId",
                table: "Medicos");
        }
    }
}
