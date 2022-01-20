using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Data.Migrations
{
    public partial class TabelaMedicamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMedicamento = table.Column<string>(nullable: true),
                    NomeGenerico = table.Column<string>(nullable: true),
                    Fabricante = table.Column<string>(nullable: true),
                    NomeFabrica = table.Column<string>(nullable: true),
                    DataFabricacao = table.Column<DateTime>(nullable: false),
                    DataVencimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicamentos");
        }
    }
}
