using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaCompanyName",
                schema: "Entertainment",
                table: "Companies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                comment: "عنوان شرکت فارسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "عنوان شرکت فارسی");

            migrationBuilder.AlterColumn<string>(
                name: "EnCompanyName",
                schema: "Entertainment",
                table: "Companies",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "عنوان شرکت انگلیسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "عنوان شرکت انگلیسی");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FaCompanyName",
                schema: "Entertainment",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "عنوان شرکت فارسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true,
                oldComment: "عنوان شرکت فارسی");

            migrationBuilder.AlterColumn<string>(
                name: "EnCompanyName",
                schema: "Entertainment",
                table: "Companies",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "عنوان شرکت انگلیسی",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldComment: "عنوان شرکت انگلیسی");
        }
    }
}
