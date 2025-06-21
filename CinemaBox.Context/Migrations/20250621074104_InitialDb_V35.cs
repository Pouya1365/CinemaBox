using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ServerName",
                schema: "Server",
                table: "Servers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "عنوان سرور",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "عنوان سرور");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "Server",
                table: "Servers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                comment: "مسیر",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true,
                oldComment: "مسیر");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ServerName",
                schema: "Server",
                table: "Servers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "عنوان سرور",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "عنوان سرور");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                schema: "Server",
                table: "Servers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                comment: "مسیر",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldComment: "مسیر");
        }
    }
}
