using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Shared",
                table: "Qualities",
                columns: new[] { "QualityId", "QualityName" },
                values: new object[] { (byte)5, "1280" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Shared",
                table: "Qualities",
                keyColumn: "QualityId",
                keyValue: (byte)5);
        }
    }
}
