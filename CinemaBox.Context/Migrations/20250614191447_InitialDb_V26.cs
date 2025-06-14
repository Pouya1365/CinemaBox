using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieTaglines",
                schema: "Entertainment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه جمله نهایی")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    EnTagline = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "محل جمله نهایی انگلیسی"),
                    FaTagline = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "محل جمله نهایی فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTaglines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTaglines_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTaglines_MovieId",
                schema: "Entertainment",
                table: "MovieTaglines",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTaglines",
                schema: "Entertainment");
        }
    }
}
