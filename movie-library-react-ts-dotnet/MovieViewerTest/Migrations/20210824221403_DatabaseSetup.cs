using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieViewerTest.Migrations
{
    public partial class DatabaseSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueryValue = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieSearchedByTitleResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalResults = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    QueryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSearchedByTitleResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieSearchedByTitleResults_Queries_QueryId",
                        column: x => x.QueryId,
                        principalTable: "Queries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesFoundByTitle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    ImdbID = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    MovieSearchedByTitleResultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesFoundByTitle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesFoundByTitle_MovieSearchedByTitleResults_MovieSearchedByTitleResultId",
                        column: x => x.MovieSearchedByTitleResultId,
                        principalTable: "MovieSearchedByTitleResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MoviesFoundByIMDbID",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Year = table.Column<string>(nullable: true),
                    ImdbID = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true),
                    Rated = table.Column<string>(nullable: true),
                    Released = table.Column<string>(nullable: true),
                    Runtime = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Writer = table.Column<string>(nullable: true),
                    Actors = table.Column<string>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Awards = table.Column<string>(nullable: true),
                    Metascore = table.Column<string>(nullable: true),
                    imdbRating = table.Column<string>(nullable: true),
                    imdbVotes = table.Column<string>(nullable: true),
                    MovieFoundByTitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesFoundByIMDbID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviesFoundByIMDbID_MoviesFoundByTitle_MovieFoundByTitleId",
                        column: x => x.MovieFoundByTitleId,
                        principalTable: "MoviesFoundByTitle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    MovieFoundByImDbId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_MoviesFoundByIMDbID_MovieFoundByImDbId",
                        column: x => x.MovieFoundByImDbId,
                        principalTable: "MoviesFoundByIMDbID",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSearchedByTitleResults_QueryId",
                table: "MovieSearchedByTitleResults",
                column: "QueryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MoviesFoundByIMDbID_MovieFoundByTitleId",
                table: "MoviesFoundByIMDbID",
                column: "MovieFoundByTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviesFoundByTitle_MovieSearchedByTitleResultId",
                table: "MoviesFoundByTitle",
                column: "MovieSearchedByTitleResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_MovieFoundByImDbId",
                table: "Ratings",
                column: "MovieFoundByImDbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "MoviesFoundByIMDbID");

            migrationBuilder.DropTable(
                name: "MoviesFoundByTitle");

            migrationBuilder.DropTable(
                name: "MovieSearchedByTitleResults");

            migrationBuilder.DropTable(
                name: "Queries");
        }
    }
}
