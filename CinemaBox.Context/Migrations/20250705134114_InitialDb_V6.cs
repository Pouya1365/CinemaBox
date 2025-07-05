using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaTagline",
                schema: "Entertainment",
                table: "MovieTaglines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                comment: "محل جمله نهایی فارسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true,
                oldComment: "محل جمله نهایی فارسی");

            migrationBuilder.AlterColumn<string>(
                name: "EnTagline",
                schema: "Entertainment",
                table: "MovieTaglines",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                comment: "محل جمله نهایی انگلیسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldComment: "محل جمله نهایی انگلیسی");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaTagline",
                schema: "Entertainment",
                table: "MovieTaglines",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                comment: "محل جمله نهایی فارسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true,
                oldComment: "محل جمله نهایی فارسی");

            migrationBuilder.AlterColumn<string>(
                name: "EnTagline",
                schema: "Entertainment",
                table: "MovieTaglines",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                comment: "محل جمله نهایی انگلیسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldComment: "محل جمله نهایی انگلیسی");
        }
    }
}
