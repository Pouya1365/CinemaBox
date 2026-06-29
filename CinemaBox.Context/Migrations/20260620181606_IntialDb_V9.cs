using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class IntialDb_V9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Shared",
                table: "Qualities",
                keyColumn: "QualityId",
                keyValue: (byte)3,
                column: "QualityName",
                value: "1280");

            migrationBuilder.UpdateData(
                schema: "Shared",
                table: "Qualities",
                keyColumn: "QualityId",
                keyValue: (byte)4,
                column: "QualityName",
                value: "720");

            migrationBuilder.UpdateData(
                schema: "Shared",
                table: "Qualities",
                keyColumn: "QualityId",
                keyValue: (byte)5,
                column: "QualityName",
                value: "480");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Shared",
                table: "Qualities",
                keyColumn: "QualityId",
                keyValue: (byte)3,
                column: "QualityName",
                value: "720");

            migrationBuilder.UpdateData(
                schema: "Shared",
                table: "Qualities",
                keyColumn: "QualityId",
                keyValue: (byte)4,
                column: "QualityName",
                value: "480");

            migrationBuilder.UpdateData(
                schema: "Shared",
                table: "Qualities",
                keyColumn: "QualityId",
                keyValue: (byte)5,
                column: "QualityName",
                value: "1280");
        }
    }
}
