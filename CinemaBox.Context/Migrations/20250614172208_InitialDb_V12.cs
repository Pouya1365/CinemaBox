using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                schema: "Server",
                columns: table => new
                {
                    ServerId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه سرور")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerTypeId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه نوع سرور"),
                    ServerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "عنوان سرور"),
                    Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "مسیر")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                    table.ForeignKey(
                        name: "FK_Servers_ServerTypes_ServerTypeId",
                        column: x => x.ServerTypeId,
                        principalSchema: "Server",
                        principalTable: "ServerTypes",
                        principalColumn: "ServerTypeId");
                });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "Servers",
                columns: new[] { "ServerId", "Path", "ServerName", "ServerTypeId" },
                values: new object[,]
                {
                    { (byte)1, "Images/People", "PeoplePrimaryImage", (byte)1 },
                    { (byte)2, "Images/Movie", "MoviePrimaryImage", (byte)2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Servers_ServerTypeId",
                schema: "Server",
                table: "Servers",
                column: "ServerTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers",
                schema: "Server");
        }
    }
}
