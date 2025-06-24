using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V37 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieAudios_Languages_LanguageId",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieAudios_Languages_LanguageId",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieAudios",
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
        }
    }
}
