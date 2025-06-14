using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeathCauses",
                schema: "Shared",
                columns: table => new
                {
                    DeathCauseId = table.Column<int>(type: "int", nullable: false, comment: "شناسه نوع فوت")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnDeathCauseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "عنوان فوت انگلیسی"),
                    FaDeathCauseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "عنوان فوت فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeathCauses", x => x.DeathCauseId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_DeathCauseId",
                schema: "Person",
                table: "Peoples",
                column: "DeathCauseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Peoples_DeathCauses_DeathCauseId",
                schema: "Person",
                table: "Peoples",
                column: "DeathCauseId",
                principalSchema: "Shared",
                principalTable: "DeathCauses",
                principalColumn: "DeathCauseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Peoples_DeathCauses_DeathCauseId",
                schema: "Person",
                table: "Peoples");

            migrationBuilder.DropTable(
                name: "DeathCauses",
                schema: "Shared");

            migrationBuilder.DropIndex(
                name: "IX_Peoples_DeathCauseId",
                schema: "Person",
                table: "Peoples");
        }
    }
}
