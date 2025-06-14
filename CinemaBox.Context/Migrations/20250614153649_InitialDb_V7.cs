using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryParts",
                schema: "Division",
                columns: table => new
                {
                    CountryPartId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه کشور")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnCountryPartName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "عنوان انگلیسی"),
                    FaCountryPartName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "عنوان فارسی"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true, comment: "شناسه پدر"),
                    IsoCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "عنوان نوع تقسیم بندی"),
                    CountryPartTypeId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه نوع کشور")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryParts", x => x.CountryPartId);
                    table.ForeignKey(
                        name: "FK_CountryParts_CountryPartTypes_CountryPartTypeId",
                        column: x => x.CountryPartTypeId,
                        principalSchema: "Division",
                        principalTable: "CountryPartTypes",
                        principalColumn: "CountryPartTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryParts_CountryPartTypeId",
                schema: "Division",
                table: "CountryParts",
                column: "CountryPartTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryParts",
                schema: "Division");
        }
    }
}
