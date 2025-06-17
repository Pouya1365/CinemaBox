using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TopRank",
                schema: "Entertainment",
                table: "Movies",
                type: "int",
                nullable: true,
                comment: "برترین فیلم",
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true,
                oldComment: "برترین فیلم");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "TopRank",
                schema: "Entertainment",
                table: "Movies",
                type: "tinyint",
                nullable: true,
                comment: "برترین فیلم",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldComment: "برترین فیلم");
        }
    }
}
