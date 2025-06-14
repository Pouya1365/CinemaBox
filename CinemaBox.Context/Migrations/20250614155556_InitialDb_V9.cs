using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.CreateTable(
                name: "Peoples",
                schema: "Person",
                columns: table => new
                {
                    PeopleId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه زده بندی سنی"),
                    EnFullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "نام انگلیسی"),
                    FaFullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "نام فارسی"),
                    BornDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاریخ تولد"),
                    DeathDate = table.Column<DateOnly>(type: "date", nullable: true, comment: "تاریخ فوت"),
                    BornPlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "محل تولد"),
                    DeathPlace = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "محل فوت"),
                    BirthName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "نام تولد"),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "معروف"),
                    Height = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "قد"),
                    EnMiniBiography = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "خلاصه زندگینامه انگلیسی"),
                    FaMiniBiography = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "خلاصه زندگینامه فارسی"),
                    DeathCauseId = table.Column<int>(type: "int", nullable: true, comment: "شناسه دلیل فوت"),
                    AddedDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاریخ اضافه شدن"),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "تاریخ بروز شدن")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.PeopleId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Peoples",
                schema: "Person");
        }
    }
}
