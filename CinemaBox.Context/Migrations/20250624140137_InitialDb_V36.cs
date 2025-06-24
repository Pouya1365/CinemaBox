using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieAudios_Users_UserId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieDisks_Users_UserId",
                schema: "Managment",
                table: "UserMovieDisks");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieVideos_Movies_MovieId",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieVideos_Users_UserId",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Usr");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovieVideos",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieVideos_MovieId",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovieDisks",
                schema: "Managment",
                table: "UserMovieDisks");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieDisks_MovieId",
                schema: "Managment",
                table: "UserMovieDisks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovieAudios",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieAudios_MovieId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieAudios_UserId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Managment",
                table: "UserMovieDisks");

            migrationBuilder.DropColumn(
                name: "UserMovieAudioId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.AddColumn<string>(
                name: "MovieId1",
                schema: "Managment",
                table: "UserMovieVideos",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "شناسه فایل صوت",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "شناسه فیلم");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieVideos",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieDisks",
                schema: "Managment",
                table: "UserMovieDisks",
                column: "MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieAudios",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieVideos_MovieId1",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieVideos_Movies_MovieId1",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId1",
                principalSchema: "Entertainment",
                principalTable: "Movies",
                principalColumn: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovieVideos_Movies_MovieId1",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovieVideos",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropIndex(
                name: "IX_UserMovieVideos_MovieId1",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovieDisks",
                schema: "Managment",
                table: "UserMovieDisks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovieAudios",
                schema: "Managment",
                table: "UserMovieAudios");

            migrationBuilder.DropColumn(
                name: "MovieId1",
                schema: "Managment",
                table: "UserMovieVideos");

            migrationBuilder.EnsureSchema(
                name: "Usr");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Managment",
                table: "UserMovieVideos",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "شناسه فرد");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Managment",
                table: "UserMovieDisks",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "شناسه فرد");

            migrationBuilder.AlterColumn<string>(
                name: "MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                comment: "شناسه فیلم",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldComment: "شناسه فایل صوت");

            migrationBuilder.AddColumn<long>(
                name: "UserMovieAudioId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                comment: "شناسه فایل صوت")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "شناسه فرد");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieVideos",
                schema: "Managment",
                table: "UserMovieVideos",
                columns: new[] { "UserId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieDisks",
                schema: "Managment",
                table: "UserMovieDisks",
                columns: new[] { "UserId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovieAudios",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "UserMovieAudioId");

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

            migrationBuilder.InsertData(
                schema: "Usr",
                table: "Users",
                columns: new[] { "UserId", "Password" },
                values: new object[] { "0078979013", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieVideos_MovieId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieDisks_MovieId",
                schema: "Managment",
                table: "UserMovieDisks",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_MovieId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_UserId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieAudios_Users_UserId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "UserId",
                principalSchema: "Usr",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieDisks_Users_UserId",
                schema: "Managment",
                table: "UserMovieDisks",
                column: "UserId",
                principalSchema: "Usr",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieVideos_Movies_MovieId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "MovieId",
                principalSchema: "Entertainment",
                principalTable: "Movies",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovieVideos_Users_UserId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "UserId",
                principalSchema: "Usr",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
