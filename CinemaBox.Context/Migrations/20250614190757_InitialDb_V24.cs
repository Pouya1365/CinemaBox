using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Shared",
                columns: table => new
                {
                    LanguageId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه زبان")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnLanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان زبان انگلیسی"),
                    FaLanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "عنوان زبان فارسی"),
                    IsoCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "کد زبان")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Shared");
        }
    }
}
