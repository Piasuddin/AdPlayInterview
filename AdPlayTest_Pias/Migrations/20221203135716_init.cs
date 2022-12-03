using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdPlayTestPias.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true),
                    ComposerName = table.Column<string>(type: "varchar(30)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 1, "GenreName 1" },
                    { 2, "GenreName 2" },
                    { 3, "GenreName 3" }
                });

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "ComposerName", "GenreId", "Name" },
                values: new object[,]
                {
                    { 1L, "ComposerName 1", 1, "Track 1" },
                    { 2L, "ComposerName 2", 1, "Track 2" },
                    { 3L, "ComposerName 3", 2, "Track 3" },
                    { 4L, "ComposerName 4", 1, "Track 4" },
                    { 5L, "ComposerName 5", 3, "Track 5" },
                    { 6L, "ComposerName 6", 1, "Track 6" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_GenreId",
                table: "Tracks",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
