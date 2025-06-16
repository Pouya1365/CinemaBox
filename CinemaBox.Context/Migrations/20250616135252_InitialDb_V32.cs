using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMovieVideos",
                schema: "Managment",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "شناسه فرد"),
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    FormatId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه نوع فرمت"),
                    BitRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "بیت ریت"),
                    FPS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "فریم در ثانیه"),
                    AspectRatio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "نسبت ابعاد"),
                    Resolution = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "وضوح تصویر")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieVideos", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_UserMovieVideos_Formats_FormatId",
                        column: x => x.FormatId,
                        principalSchema: "Shared",
                        principalTable: "Formats",
                        principalColumn: "FormatId");
                    table.ForeignKey(
                        name: "FK_UserMovieVideos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieVideos_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Usr",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieVideos_FormatId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieVideos_MovieId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovieVideos",
                schema: "Managment");
        }
    }
}
