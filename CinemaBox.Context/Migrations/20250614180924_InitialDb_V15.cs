using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditTypes",
                schema: "Entertainment",
                columns: table => new
                {
                    CreditTypeId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه نوع عوامل")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnCreditTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "نوع عوامل انگلیسی"),
                    FaCreditTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "نوع عوامل فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditTypes", x => x.CreditTypeId);
                });

            migrationBuilder.InsertData(
                schema: "Entertainment",
                table: "CreditTypes",
                columns: new[] { "CreditTypeId", "EnCreditTypeName", "FaCreditTypeName" },
                values: new object[,]
                {
                    { (byte)1, "Director", "کارگردان" },
                    { (byte)2, "Writers", "نویسنده" },
                    { (byte)3, "Cast", "بازیگران" },
                    { (byte)4, "Producers", "تهیه کنندکان" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditTypes",
                schema: "Entertainment");
        }
    }
}
