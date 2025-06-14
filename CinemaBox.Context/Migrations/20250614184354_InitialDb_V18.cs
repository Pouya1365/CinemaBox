using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "Entertainment",
                columns: table => new
                {
                    GenreId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه ژانر")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnGenreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "ژانر انگلیسی"),
                    FaGenreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "نوع ژانر فارسی"),
                    FileId = table.Column<long>(type: "bigint", nullable: true, comment: "شناسه فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genres_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "Files",
                        principalTable: "Files",
                        principalColumn: "FileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_FileId",
                schema: "Entertainment",
                table: "Genres",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres",
                schema: "Entertainment");
        }
    }
}
