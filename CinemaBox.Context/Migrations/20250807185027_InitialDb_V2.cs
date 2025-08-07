using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaKeyowrdName",
                schema: "Shared",
                table: "Keywords",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                comment: "کلمه کلیدی فارسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "کلمه کلیدی فارسی");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaKeyowrdName",
                schema: "Shared",
                table: "Keywords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "کلمه کلیدی فارسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true,
                oldComment: "کلمه کلیدی فارسی");
        }
    }
}
