using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Managment");

            migrationBuilder.CreateTable(
                name: "UserMovieDisks",
                schema: "Managment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    UserId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "شناسه فرد"),
                    MyTime = table.Column<int>(type: "int", nullable: true, comment: "زمان فیلم من"),
                    PositionMovie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "محل قرارگیری فیلم"),
                    MovieNumber = table.Column<int>(type: "int", nullable: true, comment: "شماره فیلم"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "نام فایل"),
                    FileSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "اندازه فایل"),
                    IsDubbed = table.Column<bool>(type: "bit", nullable: true, comment: "دوبله"),
                    IsSubtitle = table.Column<bool>(type: "bit", nullable: true, comment: "زیرنویس"),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه وضعیت")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieDisks", x => new { x.UserId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_UserMovieDisks_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieDisks_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Shared",
                        principalTable: "Statuses",
                        principalColumn: "StatusId");
                    table.ForeignKey(
                        name: "FK_UserMovieDisks_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Usr",
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieDisks_MovieId",
                schema: "Managment",
                table: "UserMovieDisks",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieDisks_StatusId",
                schema: "Managment",
                table: "UserMovieDisks",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovieDisks",
                schema: "Managment");
        }
    }
}
