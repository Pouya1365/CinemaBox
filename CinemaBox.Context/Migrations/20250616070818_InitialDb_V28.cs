using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "Shared",
                columns: table => new
                {
                    StatusId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه وضعیت")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان زبان انگلیسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.InsertData(
                schema: "Shared",
                table: "Statuses",
                columns: new[] { "StatusId", "SatusName" },
                values: new object[,]
                {
                    { (byte)1, "درخواست" },
                    { (byte)2, "آرشیو" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "Shared");
        }
    }
}
