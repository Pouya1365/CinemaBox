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
            migrationBuilder.AlterColumn<decimal>(
                name: "FileSize",
                schema: "Managment",
                table: "UserMovieDisks",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true,
                comment: "اندازه فایل",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldComment: "اندازه فایل");

            migrationBuilder.AlterColumn<int>(
                name: "UserMovieAudioId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "int",
                nullable: false,
                comment: "شناسه صدا",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "شناسه فیلم")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "AggregateRating",
                schema: "Entertainment",
                table: "Movies",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: true,
                comment: "رتبه بندی کل",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true,
                oldComment: "رتبه بندی کل");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "FileSize",
                schema: "Managment",
                table: "UserMovieDisks",
                type: "decimal(18,2)",
                nullable: true,
                comment: "اندازه فایل",
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldPrecision: 18,
                oldScale: 4,
                oldNullable: true,
                oldComment: "اندازه فایل");

            migrationBuilder.AlterColumn<int>(
                name: "UserMovieAudioId",
                schema: "Managment",
                table: "UserMovieAudios",
                type: "int",
                nullable: false,
                comment: "شناسه فیلم",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "شناسه صدا")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<decimal>(
                name: "AggregateRating",
                schema: "Entertainment",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: true,
                comment: "رتبه بندی کل",
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2,
                oldNullable: true,
                oldComment: "رتبه بندی کل");
        }
    }
}
