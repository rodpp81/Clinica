using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Data.Migrations
{
    public partial class TabelaAgendaMedica : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendaMedicas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(nullable: false),
                    DataDisponivel = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaMedicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgendaMedicas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendaMedicas_MedicoId",
                table: "AgendaMedicas",
                column: "MedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendaMedicas");
        }
    }
}
