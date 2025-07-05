using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EnKeyowrdName",
                schema: "Shared",
                table: "Keywords",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "کلمه کلیدی انگلیسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "کلمه کلیدی انگلیسی");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EnKeyowrdName",
                schema: "Shared",
                table: "Keywords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "کلمه کلیدی انگلیسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "کلمه کلیدی انگلیسی");
        }
    }
}
