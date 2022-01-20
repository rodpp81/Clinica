using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Data.Migrations
{
    public partial class seedDataExameTipo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposExames",
                columns: table => new
                {
                    TiposExameID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposExames", x => x.TiposExameID);
                });

            migrationBuilder.InsertData(
                table: "ExameTipos",
                columns: new[] { "Id", "Descricao" },
                values: new object[,]
                {
                    { 1, "HEMOGRAMA" },
                    { 2, "ELETROCARDIOGRAMA" },
                    { 3, "UREIA E CREATINA" },
                    { 4, "ULTRASSON" },
                    { 5, "TESTE ERGOMÉTRICO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TiposExames");

            migrationBuilder.DeleteData(
                table: "ExameTipos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExameTipos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExameTipos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ExameTipos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ExameTipos",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
