using Microsoft.EntityFrameworkCore.Migrations;

namespace Clinica.Data.Migrations
{
    public partial class Tabelasperfisdeusaurios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoUsuariosTipoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescricaoTipoUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuariosTipoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcessoTipoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeFuncionalidade = table.Column<string>(nullable: true),
                    TipoUsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcessoTipoUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcessoTipoUsuarios_TipoUsuariosTipoUsuarios_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuariosTipoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerfilUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoUsuarioId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    AcessoTipoUsuarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfilUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarios_AcessoTipoUsuarios_AcessoTipoUsuarioId",
                        column: x => x.AcessoTipoUsuarioId,
                        principalTable: "AcessoTipoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarios_TipoUsuariosTipoUsuarios_TipoUsuarioId",
                        column: x => x.TipoUsuarioId,
                        principalTable: "TipoUsuariosTipoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfilUsuarios_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcessoTipoUsuarios_TipoUsuarioId",
                table: "AcessoTipoUsuarios",
                column: "TipoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarios_AcessoTipoUsuarioId",
                table: "PerfilUsuarios",
                column: "AcessoTipoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarios_TipoUsuarioId",
                table: "PerfilUsuarios",
                column: "TipoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfilUsuarios_UserId",
                table: "PerfilUsuarios",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerfilUsuarios");

            migrationBuilder.DropTable(
                name: "AcessoTipoUsuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuariosTipoUsuarios");
        }
    }
}
