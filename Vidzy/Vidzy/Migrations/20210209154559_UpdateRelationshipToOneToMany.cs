using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidzy.Migrations
{
    public partial class UpdateRelationshipToOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "GenreId",
            table: "Videos",
            nullable: true);

            migrationBuilder.Sql("UPDATE Videos SET Videos.GenreId = VideoGenre.GenreId FROM Videos INNER JOIN VideoGenre ON Videos.Id = VideoGenre.VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_GenreId",
                table: "Videos",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Genres_GenreId",
                table: "Videos",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropTable(
                name: "VideoGenre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Genres_GenreId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_GenreId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Videos");

            migrationBuilder.CreateTable(
                name: "VideoGenre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGenre", x => new { x.GenreId, x.VideoId });
                    table.ForeignKey(
                        name: "FK_VideoGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGenre_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGenre_VideoId",
                table: "VideoGenre",
                column: "VideoId");
        }
    }
}
