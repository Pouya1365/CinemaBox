using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaBox.Context.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb_V0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Entertainment");

            migrationBuilder.CreateTable(
                name: "Movies",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم یا سریال"),
                    EnTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "عنوان انگلیسی"),
                    FaTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "عنوان فارسی"),
                    OriginalTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "عنوان اصلی"),
                    StartYear = table.Column<long>(type: "bigint", nullable: true, comment: "سال فیلم یا سال شروع سریال"),
                    EndYear = table.Column<long>(type: "bigint", nullable: true, comment: "تاریخ پایان سریال"),
                    CertificateId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه درجه بندی سنی"),
                    RunTimeMinutes = table.Column<long>(type: "bigint", nullable: true, comment: "مدت زمان فیلم یا سریال"),
                    ReleaseYear = table.Column<long>(type: "bigint", nullable: true, comment: "سال انتشار"),
                    ReleaseMonth = table.Column<long>(type: "bigint", nullable: true, comment: "ماه انتشار"),
                    ReleaseDay = table.Column<long>(type: "bigint", nullable: true, comment: "روز انتشار"),
                    AggregateRating = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "رتبه بندی کل"),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true, comment: "تعداد رای دهندگان"),
                    Winner = table.Column<long>(type: "bigint", nullable: true, comment: "تعداد جوایز"),
                    Nomination = table.Column<long>(type: "bigint", nullable: true, comment: "نامزد شدن"),
                    EnPlot = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "خلاصه داستان انگلیسی"),
                    EnStoryline = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "داستان انگلیسی"),
                    Budget = table.Column<double>(type: "float", nullable: true, comment: "بودجه"),
                    FaStoryline = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "داستان فارسی"),
                    TopRank = table.Column<byte>(type: "tinyint", nullable: true, comment: "برترین فیلم"),
                    OscarWins = table.Column<byte>(type: "tinyint", nullable: true, comment: "تعداد برنده اسکار"),
                    OscarNominations = table.Column<byte>(type: "tinyint", nullable: true, comment: "تعداد نامزد اسکار"),
                    BudgetCurrencyId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه واحد پول بودجه"),
                    IsTvShow = table.Column<bool>(type: "bit", nullable: true, comment: "سریال"),
                    CollectionId = table.Column<int>(type: "int", nullable: true, comment: "شناسه کالکشن")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies",
                schema: "Entertainment");
        }
    }
}
