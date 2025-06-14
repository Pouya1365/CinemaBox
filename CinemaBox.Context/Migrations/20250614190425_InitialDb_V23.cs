using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieLocations",
                schema: "Entertainment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه محل فیلم برداری")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    LocationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "محل فیلم برداری")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieLocations_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieLocations_MovieId",
                schema: "Entertainment",
                table: "MovieLocations",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieLocations",
                schema: "Entertainment");
        }
    }
}
