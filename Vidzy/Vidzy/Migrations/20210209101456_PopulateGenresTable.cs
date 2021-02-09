using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidzy.Migrations
{
    public partial class PopulateGenresTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres VALUES ('Action')");
            migrationBuilder.Sql("INSERT INTO Genres VALUES ('History')");
            migrationBuilder.Sql("INSERT INTO Genres VALUES ('Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres VALUES ('SciFi')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
