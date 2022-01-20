using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Data.Migrations
{
    public partial class TabelaExameAgenda8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Receita",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "NomePaciente",
                table: "Pacientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pacientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Pacientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    TipoExameId = table.Column<int>(nullable: false),
                    ExameTipoId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_ExameTipos_ExameTipoId",
                        column: x => x.ExameTipoId,
                        principalTable: "ExameTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Exame_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exame_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExameAgendas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    ExameId = table.Column<int>(nullable: false),
                    ExameTipoId = table.Column<int>(nullable: true),
                    PacienteId = table.Column<int>(nullable: false),
                    MedicoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExameAgendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExameAgendas_ExameTipos_ExameTipoId",
                        column: x => x.ExameTipoId,
                        principalTable: "ExameTipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExameAgendas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExameAgendas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Receita_PacienteId",
                table: "Receita",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_ExameTipoId",
                table: "Exame",
                column: "ExameTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_MedicoId",
                table: "Exame",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exame_PacienteId",
                table: "Exame",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExameAgendas_ExameTipoId",
                table: "ExameAgendas",
                column: "ExameTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExameAgendas_MedicoId",
                table: "ExameAgendas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExameAgendas_PacienteId",
                table: "ExameAgendas",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receita_Pacientes_PacienteId",
                table: "Receita",
                column: "PacienteId",
                principalTable: "Pacientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receita_Pacientes_PacienteId",
                table: "Receita");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "ExameAgendas");

            migrationBuilder.DropIndex(
                name: "IX_Receita_PacienteId",
                table: "Receita");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Receita");

            migrationBuilder.AlterColumn<string>(
                name: "NomePaciente",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Pacientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "TiposExames",
                columns: table => new
                {
                    TiposExameID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposExames", x => x.TiposExameID);
                });
        }
    }
}
