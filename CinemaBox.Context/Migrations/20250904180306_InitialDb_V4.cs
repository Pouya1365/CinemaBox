using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaKeyowrdName",
                schema: "Shared",
                table: "Keywords",
                newName: "FaKeywordName");

            migrationBuilder.RenameColumn(
                name: "EnKeyowrdName",
                schema: "Shared",
                table: "Keywords",
                newName: "EnKeywordName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaKeywordName",
                schema: "Shared",
                table: "Keywords",
                newName: "FaKeyowrdName");

            migrationBuilder.RenameColumn(
                name: "EnKeywordName",
                schema: "Shared",
                table: "Keywords",
                newName: "EnKeyowrdName");
        }
    }
}
