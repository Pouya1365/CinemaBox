using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certificates",
                schema: "Entertainment",
                columns: table => new
                {
                    CertificateId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه زده بندی سنی")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "نام درجه بندی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CertificateId",
                schema: "Entertainment",
                table: "Movies",
                column: "CertificateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Certificates_CertificateId",
                schema: "Entertainment",
                table: "Movies",
                column: "CertificateId",
                principalSchema: "Entertainment",
                principalTable: "Certificates",
                principalColumn: "CertificateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Certificates_CertificateId",
                schema: "Entertainment",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Certificates",
                schema: "Entertainment");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CertificateId",
                schema: "Entertainment",
                table: "Movies");
        }
    }
}
