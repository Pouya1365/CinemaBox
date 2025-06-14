using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PeopleFiles",
                schema: "Person",
                columns: table => new
                {
                    PeopleId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه بازیگر"),
                    FileId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleFiles", x => new { x.PeopleId, x.FileId });
                    table.ForeignKey(
                        name: "FK_PeopleFiles_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "Files",
                        principalTable: "Files",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleFiles_Peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalSchema: "Person",
                        principalTable: "Peoples",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleFiles_FileId",
                schema: "Person",
                table: "PeopleFiles",
                column: "FileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleFiles",
                schema: "Person");
        }
    }
}
