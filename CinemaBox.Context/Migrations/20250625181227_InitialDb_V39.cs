using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V39 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMovieFile",
                schema: "Managment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    FileId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieFile", x => new { x.MovieId, x.FileId });
                    table.ForeignKey(
                        name: "FK_UserMovieFile_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "Files",
                        principalTable: "Files",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieFile_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "ServerTypes",
                columns: new[] { "ServerTypeId", "ServerTypeName" },
                values: new object[] { (byte)3, "UserMovie" });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "Servers",
                columns: new[] { "ServerId", "Path", "ServerName", "ServerTypeId" },
                values: new object[] { (byte)3, "Images/UserMovie", "UserMoviePrimaryImage", (byte)3 });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieFile_FileId",
                schema: "Managment",
                table: "UserMovieFile",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovieFile",
                schema: "Managment");

            migrationBuilder.DeleteData(
                schema: "Server",
                table: "Servers",
                keyColumn: "ServerId",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                schema: "Server",
                table: "ServerTypes",
                keyColumn: "ServerTypeId",
                keyValue: (byte)3);
        }
    }
}
