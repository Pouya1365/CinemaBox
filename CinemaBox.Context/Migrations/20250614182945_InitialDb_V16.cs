using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieCredits",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    PeopleId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه بازیگر"),
                    CreditTypeId = table.Column<byte>(type: "tinyint", nullable: false, comment: "خلاصه نوع عامل"),
                    IsLead = table.Column<bool>(type: "bit", nullable: true, comment: "بازیگر اصلی"),
                    RoleName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "نام نقش")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCredits", x => new { x.PeopleId, x.MovieId, x.CreditTypeId });
                    table.ForeignKey(
                        name: "FK_MovieCredits_CreditTypes_CreditTypeId",
                        column: x => x.CreditTypeId,
                        principalSchema: "Entertainment",
                        principalTable: "CreditTypes",
                        principalColumn: "CreditTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCredits_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCredits_Peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalSchema: "Person",
                        principalTable: "Peoples",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieCredits_CreditTypeId",
                schema: "Entertainment",
                table: "MovieCredits",
                column: "CreditTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCredits_MovieId",
                schema: "Entertainment",
                table: "MovieCredits",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCredits",
                schema: "Entertainment");
        }
    }
}
