using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Files");

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "Files",
                columns: table => new
                {
                    FileId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه فایل")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه  سرور"),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "عنوان فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_Servers_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "Server",
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_ServerId",
                schema: "Files",
                table: "Files",
                column: "ServerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files",
                schema: "Files");
        }
    }
}
