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
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieAudios_Languages_LanguageId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieAudios_Movies_MovieId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovieAudios",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.AlterColumn<byte>(
                name: "LanguageId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "tinyint",
                nullable: true,
                comment: "شناسه زبان",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldComment: "شناسه زبان");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                comment: "شناسه فیلم",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "شناسه فایل صوت");

            migrationBuilder.AddColumn<int>(
                name: "UserMovieAudioId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "شناسه فیلم")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieAudios",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "UserMovieAudioId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieAudios_Languages_LanguageId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "LanguageId",
                principalSchema: "Shared",
                principalTable: "Languages",
                principalColumn: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieAudios_Movies_MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "MovieId",
                principalSchema: "Entertainment",
                principalTable: "Movies",
                principalColumn: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieAudios_Languages_LanguageId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieAudios_Movies_MovieId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovieAudios",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieAudios_MovieId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropColumn(
                name: "UserMovieAudioId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                comment: "شناسه فایل صوت",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldComment: "شناسه فیلم");

            migrationBuilder.AlterColumn<byte>(
                name: "LanguageId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                comment: "شناسه زبان",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true,
                oldComment: "شناسه زبان");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieAudios",
                schema: "Managment",
                table: "UserMovieAudios",
                columns: new[] { "MovieId", "LanguageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieAudios_Languages_LanguageId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "LanguageId",
                principalSchema: "Shared",
                principalTable: "Languages",
                principalColumn: "LanguageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieAudios_Movies_MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "MovieId",
                principalSchema: "Entertainment",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
