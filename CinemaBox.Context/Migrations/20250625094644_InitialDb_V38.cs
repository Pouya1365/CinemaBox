using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V38 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieVideos_Movies_MovieId1",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieVideos_MovieId1",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieVideos_Movies_MovieId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId",
                principalSchema: "Entertainment",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieVideos_Movies_MovieId",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.AddColumn<string>(
                name: "MovieId1",
                schema: "Managment",
                table: "UserMovieVideos",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieVideos_MovieId1",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieVideos_Movies_MovieId1",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId1",
                principalSchema: "Entertainment",
                principalTable: "Movies",
                principalColumn: "MovieId");
        }
    }
}
