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
            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Entertainment",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه شزکت"),
                    EnCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان شرکت انگلیسی"),
                    FaCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "عنوان شرکت فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Entertainment");
        }
    }
}
