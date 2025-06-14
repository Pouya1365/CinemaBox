using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieSpokenLanguages",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    LanguageId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه زبان")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSpokenLanguages", x => new { x.MovieId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_MovieSpokenLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Shared",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSpokenLanguages_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSpokenLanguages_LanguageId",
                schema: "Entertainment",
                table: "MovieSpokenLanguages",
                column: "LanguageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSpokenLanguages",
                schema: "Entertainment");
        }
    }
}
