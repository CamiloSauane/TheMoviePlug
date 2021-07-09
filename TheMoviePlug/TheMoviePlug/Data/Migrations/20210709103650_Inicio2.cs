using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMoviePlug.Data.Migrations
{
    public partial class Inicio2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.CreateTable(
                name: "FilmesUtilizadores",
                columns: table => new
                {
                    ListaFilmesFavId = table.Column<int>(type: "int", nullable: false),
                    ListaUtilizadoresFavId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesUtilizadores", x => new { x.ListaFilmesFavId, x.ListaUtilizadoresFavId });
                    table.ForeignKey(
                        name: "FK_FilmesUtilizadores_Filmes_ListaFilmesFavId",
                        column: x => x.ListaFilmesFavId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmesUtilizadores_Utilizadores_ListaUtilizadoresFavId",
                        column: x => x.ListaUtilizadoresFavId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmesUtilizadores_ListaUtilizadoresFavId",
                table: "FilmesUtilizadores",
                column: "ListaUtilizadoresFavId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmesUtilizadores");

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    ListaFilmesFavId = table.Column<int>(type: "int", nullable: false),
                    ListaUtilizadoresFavId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => new { x.ListaFilmesFavId, x.ListaUtilizadoresFavId });
                    table.ForeignKey(
                        name: "FK_Favoritos_Filmes_ListaFilmesFavId",
                        column: x => x.ListaFilmesFavId,
                        principalTable: "Filmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favoritos_Utilizadores_ListaUtilizadoresFavId",
                        column: x => x.ListaUtilizadoresFavId,
                        principalTable: "Utilizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favoritos_ListaUtilizadoresFavId",
                table: "Favoritos",
                column: "ListaUtilizadoresFavId");
        }
    }
}
