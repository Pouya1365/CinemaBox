using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Usr");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Usr",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "شناسه کاربر"),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "رمز عبور")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "Usr");
        }
    }
}
