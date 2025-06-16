using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V31 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMovieAudios",
                schema: "Managment",
                columns: table => new
                {
                    UserMovieAudioId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه فایل صوت")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه زبان"),
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    Channels = table.Column<byte>(type: "tinyint", nullable: true, comment: "فریم در ثانیه"),
                    FormatId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه نوع فرمت"),
                    UserId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "شناسه فرد")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieAudios", x => x.UserMovieAudioId);
                    table.ForeignKey(
                        name: "FK_UserMovieAudios_Formats_FormatId",
                        column: x => x.FormatId,
                        principalSchema: "Shared",
                        principalTable: "Formats",
                        principalColumn: "FormatId");
                    table.ForeignKey(
                        name: "FK_UserMovieAudios_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Shared",
                        principalTable: "Languages",
                        principalColumn: "LanguageId");
                    table.ForeignKey(
                        name: "FK_UserMovieAudios_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieAudios_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Usr",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_FormatId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_LanguageId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_UserId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovieAudios",
                schema: "Managment");
        }
    }
}
