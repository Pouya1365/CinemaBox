using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Division");

            migrationBuilder.CreateTable(
                name: "CountryPartTypes",
                schema: "Division",
                columns: table => new
                {
                    CountryPartTypeId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه نوع تقسیم بندی")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryPartTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان نوع تقسیم بندی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryPartTypes", x => x.CountryPartTypeId);
                });

            migrationBuilder.InsertData(
                schema: "Division",
                table: "CountryPartTypes",
                columns: new[] { "CountryPartTypeId", "CountryPartTypeName" },
                values: new object[,]
                {
                    { (byte)1, "کشور" },
                    { (byte)2, "استان" },
                    { (byte)3, "شهرستان" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryPartTypes",
                schema: "Division");
        }
    }
}
