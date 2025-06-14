using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                schema: "Entertainment",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "int", nullable: false, comment: "شناسه کالکشن")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnCollectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "نام کالکشن انگلیسی"),
                    FaCollectionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "نام کالکشن فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CollectionId",
                schema: "Entertainment",
                table: "Movies",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Collections_CollectionId",
                schema: "Entertainment",
                table: "Movies",
                column: "CollectionId",
                principalSchema: "Entertainment",
                principalTable: "Collections",
                principalColumn: "CollectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Collections_CollectionId",
                schema: "Entertainment",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Collections",
                schema: "Entertainment");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CollectionId",
                schema: "Entertainment",
                table: "Movies");
        }
    }
}
