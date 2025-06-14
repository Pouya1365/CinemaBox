using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keywords",
                schema: "Entertainment",
                columns: table => new
                {
                    KeywordId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه کلمه کلیدی"),
                    EnKeyowrdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "کلمه کلیدی انگلیسی"),
                    FaKeyowrdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "کلمه کلیدی فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.KeywordId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keywords",
                schema: "Entertainment");
        }
    }
}
