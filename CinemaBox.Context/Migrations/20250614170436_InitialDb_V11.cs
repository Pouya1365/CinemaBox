using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Server");

            migrationBuilder.CreateTable(
                name: "ServerTypes",
                schema: "Server",
                columns: table => new
                {
                    ServerTypeId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه نوع سرور")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان سرور")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerTypes", x => x.ServerTypeId);
                });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "ServerTypes",
                columns: new[] { "ServerTypeId", "ServerTypeName" },
                values: new object[,]
                {
                    { (byte)1, "People" },
                    { (byte)2, "Movie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServerTypes",
                schema: "Server");
        }
    }
}
