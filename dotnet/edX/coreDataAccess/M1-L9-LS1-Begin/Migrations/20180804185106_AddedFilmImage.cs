using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieApp.Migrations
{
    public partial class AddedFilmImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmImageId",
                table: "film",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmImage",
                columns: table => new
                {
                    FilmImageId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmImage", x => x.FilmImageId);
                    table.ForeignKey(
                        name: "FK_FilmImage_film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_film_FilmImageId",
                table: "film",
                column: "FilmImageId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmImage_FilmId",
                table: "FilmImage",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_film_FilmImage_FilmImageId",
                table: "film",
                column: "FilmImageId",
                principalTable: "FilmImage",
                principalColumn: "FilmImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_film_FilmImage_FilmImageId",
                table: "film");

            migrationBuilder.DropTable(
                name: "FilmImage");

            migrationBuilder.DropIndex(
                name: "IX_film_FilmImageId",
                table: "film");

            migrationBuilder.DropColumn(
                name: "FilmImageId",
                table: "film");
        }
    }
}
