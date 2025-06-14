using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.CreateTable(
                name: "Currencies",
                schema: "Shared",
                columns: table => new
                {
                    CurrencyId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه واحد پولی")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان واحد پولی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.CurrencyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_BudgetCurrencyId",
                schema: "Entertainment",
                table: "Movies",
                column: "BudgetCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Currencies_BudgetCurrencyId",
                schema: "Entertainment",
                table: "Movies",
                column: "BudgetCurrencyId",
                principalSchema: "Shared",
                principalTable: "Currencies",
                principalColumn: "CurrencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Currencies_BudgetCurrencyId",
                schema: "Entertainment",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Shared");

            migrationBuilder.DropIndex(
                name: "IX_Movies_BudgetCurrencyId",
                schema: "Entertainment",
                table: "Movies");
        }
    }
}
