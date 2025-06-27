using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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

            migrationBuilder.EnsureSchema(
                name: "Division");

            migrationBuilder.EnsureSchema(
                name: "Shared");

            migrationBuilder.EnsureSchema(
                name: "Files");

            migrationBuilder.EnsureSchema(
                name: "Person");

            migrationBuilder.EnsureSchema(
                name: "Server");

            migrationBuilder.EnsureSchema(
                name: "Managment");

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

            migrationBuilder.CreateTable(
                name: "Companies",
                schema: "Entertainment",
                columns: table => new
                {
                    CompanyId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه شزکت"),
                    EnCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان شرکت انگلیسی"),
                    FaCompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "عنوان شرکت فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "CountryPartTypes",
                schema: "Division",
                columns: table => new
                {
                    CountryPartTypeId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه نوع تقسیم بندی")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryPartTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان نوع تقسیم بندی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryPartTypes", x => x.CountryPartTypeId);
                });

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

            migrationBuilder.CreateTable(
                name: "Formats",
                schema: "Shared",
                columns: table => new
                {
                    FormatId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه فرمت")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormatName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان فرمت")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.FormatId);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                schema: "Shared",
                columns: table => new
                {
                    KeywordId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه کلمه کلیدی"),
                    EnKeyowrdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "کلمه کلیدی انگلیسی"),
                    FaKeyowrdName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "کلمه کلیدی فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.KeywordId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Shared",
                columns: table => new
                {
                    LanguageId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه زبان")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnLanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان زبان انگلیسی"),
                    FaLanguageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "عنوان زبان فارسی"),
                    IsoCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "کد زبان")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Qualities",
                schema: "Shared",
                columns: table => new
                {
                    QualityId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه کیفیت کلیدی")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان کیفیت")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualities", x => x.QualityId);
                });

            migrationBuilder.CreateTable(
                name: "QualityTypes",
                schema: "Shared",
                columns: table => new
                {
                    QualityTypeId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه نوع کیفیت کلیدی")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualityTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان نوع کیفیت")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityTypes", x => x.QualityTypeId);
                });

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

            migrationBuilder.CreateTable(
                name: "Statuses",
                schema: "Shared",
                columns: table => new
                {
                    StatusId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه وضعیت")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SatusName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان زبان انگلیسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "CountryParts",
                schema: "Division",
                columns: table => new
                {
                    CountryPartId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه کشور")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnCountryPartName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "عنوان انگلیسی"),
                    FaCountryPartName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true, comment: "عنوان فارسی"),
                    ParentId = table.Column<long>(type: "bigint", nullable: true, comment: "شناسه پدر"),
                    IsoCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true, comment: "عنوان نوع تقسیم بندی"),
                    CountryPartTypeId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه نوع کشور")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryParts", x => x.CountryPartId);
                    table.ForeignKey(
                        name: "FK_CountryParts_CountryPartTypes_CountryPartTypeId",
                        column: x => x.CountryPartTypeId,
                        principalSchema: "Division",
                        principalTable: "CountryPartTypes",
                        principalColumn: "CountryPartTypeId");
                });

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
                    TopRank = table.Column<int>(type: "int", nullable: true, comment: "برترین فیلم"),
                    OscarWins = table.Column<byte>(type: "tinyint", nullable: true, comment: "تعداد برنده اسکار"),
                    OscarNominations = table.Column<byte>(type: "tinyint", nullable: true, comment: "تعداد نامزد اسکار"),
                    BudgetCurrencyId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه واحد پول بودجه"),
                    IsTvShow = table.Column<bool>(type: "bit", nullable: true, comment: "سریال"),
                    CollectionId = table.Column<int>(type: "int", nullable: true, comment: "شناسه کالکشن")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalSchema: "Entertainment",
                        principalTable: "Certificates",
                        principalColumn: "CertificateId");
                    table.ForeignKey(
                        name: "FK_Movies_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalSchema: "Entertainment",
                        principalTable: "Collections",
                        principalColumn: "CollectionId");
                    table.ForeignKey(
                        name: "FK_Movies_Currencies_BudgetCurrencyId",
                        column: x => x.BudgetCurrencyId,
                        principalSchema: "Shared",
                        principalTable: "Currencies",
                        principalColumn: "CurrencyId");
                });

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
                    table.ForeignKey(
                        name: "FK_Peoples_DeathCauses_DeathCauseId",
                        column: x => x.DeathCauseId,
                        principalSchema: "Shared",
                        principalTable: "DeathCauses",
                        principalColumn: "DeathCauseId");
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                schema: "Server",
                columns: table => new
                {
                    ServerId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه سرور")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerTypeId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه نوع سرور"),
                    ServerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "عنوان سرور"),
                    Path = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false, comment: "مسیر")
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

            migrationBuilder.CreateTable(
                name: "MovieCompanies",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    CompanyId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه شرکت")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCompanies", x => new { x.MovieId, x.CompanyId });
                    table.ForeignKey(
                        name: "FK_MovieCompanies_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalSchema: "Entertainment",
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCompanies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCountries",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    CountryPartId = table.Column<long>(type: "bigint", maxLength: 20, nullable: false, comment: "شناسه کشور")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCountries", x => new { x.MovieId, x.CountryPartId });
                    table.ForeignKey(
                        name: "FK_MovieCountries_CountryParts_CountryPartId",
                        column: x => x.CountryPartId,
                        principalSchema: "Division",
                        principalTable: "CountryParts",
                        principalColumn: "CountryPartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCountries_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieKeywords",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    KeywordId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه کلمه کلیدی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieKeywords", x => new { x.MovieId, x.KeywordId });
                    table.ForeignKey(
                        name: "FK_MovieKeywords_Keywords_KeywordId",
                        column: x => x.KeywordId,
                        principalSchema: "Shared",
                        principalTable: "Keywords",
                        principalColumn: "KeywordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieKeywords_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLocations",
                schema: "Entertainment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه محل فیلم برداری")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    LocationName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "محل فیلم برداری")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieLocations_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieSpokenLanguages",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    LanguageId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه زبان")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSpokenLanguages", x => new { x.MovieId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_MovieSpokenLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Shared",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieSpokenLanguages_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieTaglines",
                schema: "Entertainment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه جمله نهایی")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    EnTagline = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "محل جمله نهایی انگلیسی"),
                    FaTagline = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "محل جمله نهایی فارسی")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTaglines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTaglines_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMovieAudios",
                schema: "Managment",
                columns: table => new
                {
                    LanguageId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه زبان"),
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فایل صوت"),
                    Channels = table.Column<byte>(type: "tinyint", nullable: true, comment: "فریم در ثانیه"),
                    FormatId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه نوع فرمت")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieAudios", x => new { x.MovieId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_UserMovieAudios_Formats_FormatId",
                        column: x => x.FormatId,
                        principalSchema: "Shared",
                        principalTable: "Formats",
                        principalColumn: "FormatId");
                    table.ForeignKey(
                        name: "FK_UserMovieAudios_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Shared",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieAudios_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMovieDisks",
                schema: "Managment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    MyTime = table.Column<int>(type: "int", nullable: true, comment: "زمان فیلم من"),
                    PositionMovie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "محل قرارگیری فیلم"),
                    MovieNumber = table.Column<int>(type: "int", nullable: true, comment: "شماره فیلم"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "نام فایل"),
                    FileSize = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "اندازه فایل"),
                    IsDubbed = table.Column<bool>(type: "bit", nullable: true, comment: "دوبله"),
                    IsSubtitle = table.Column<bool>(type: "bit", nullable: true, comment: "زیرنویس"),
                    StatusId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه وضعیت"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true, comment: "توضیحات")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieDisks", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_UserMovieDisks_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieDisks_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "Shared",
                        principalTable: "Statuses",
                        principalColumn: "StatusId");
                });

            migrationBuilder.CreateTable(
                name: "UserMovieVideos",
                schema: "Managment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    FormatId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه نوع فرمت"),
                    BitRate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "بیت ریت"),
                    FPS = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "فریم در ثانیه"),
                    AspectRatio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "نسبت ابعاد"),
                    Resolution = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "وضوح تصویر"),
                    QualityId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه کیفیت"),
                    QualityTypeId = table.Column<byte>(type: "tinyint", nullable: true, comment: "شناسه  نوع کیفیت"),
                    X265 = table.Column<bool>(type: "bit", nullable: true, comment: "X265")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieVideos", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_UserMovieVideos_Formats_FormatId",
                        column: x => x.FormatId,
                        principalSchema: "Shared",
                        principalTable: "Formats",
                        principalColumn: "FormatId");
                    table.ForeignKey(
                        name: "FK_UserMovieVideos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieVideos_Qualities_QualityId",
                        column: x => x.QualityId,
                        principalSchema: "Shared",
                        principalTable: "Qualities",
                        principalColumn: "QualityId");
                    table.ForeignKey(
                        name: "FK_UserMovieVideos_QualityTypes_QualityTypeId",
                        column: x => x.QualityTypeId,
                        principalSchema: "Shared",
                        principalTable: "QualityTypes",
                        principalColumn: "QualityTypeId");
                });

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

            migrationBuilder.CreateTable(
                name: "Files",
                schema: "Files",
                columns: table => new
                {
                    FileId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه فایل")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه  سرور"),
                    FileName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "عنوان فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_Servers_ServerId",
                        column: x => x.ServerId,
                        principalSchema: "Server",
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "Entertainment",
                columns: table => new
                {
                    GenreId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه ژانر")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnGenreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "ژانر انگلیسی"),
                    FaGenreName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "نوع ژانر فارسی"),
                    FileId = table.Column<long>(type: "bigint", nullable: true, comment: "شناسه فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genres_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "Files",
                        principalTable: "Files",
                        principalColumn: "FileId");
                });

            migrationBuilder.CreateTable(
                name: "MovieFiles",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    FileId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieFiles", x => new { x.MovieId, x.FileId });
                    table.ForeignKey(
                        name: "FK_MovieFiles_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "Files",
                        principalTable: "Files",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieFiles_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleFiles",
                schema: "Person",
                columns: table => new
                {
                    PeopleId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه بازیگر"),
                    FileId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleFiles", x => new { x.PeopleId, x.FileId });
                    table.ForeignKey(
                        name: "FK_PeopleFiles_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "Files",
                        principalTable: "Files",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleFiles_Peoples_PeopleId",
                        column: x => x.PeopleId,
                        principalSchema: "Person",
                        principalTable: "Peoples",
                        principalColumn: "PeopleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserMovieFile",
                schema: "Managment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    FileId = table.Column<long>(type: "bigint", nullable: false, comment: "شناسه فایل")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovieFile", x => new { x.MovieId, x.FileId });
                    table.ForeignKey(
                        name: "FK_UserMovieFile_Files_FileId",
                        column: x => x.FileId,
                        principalSchema: "Files",
                        principalTable: "Files",
                        principalColumn: "FileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMovieFile_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenres",
                schema: "Entertainment",
                columns: table => new
                {
                    MovieId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "شناسه فیلم"),
                    GenreId = table.Column<byte>(type: "tinyint", nullable: false, comment: "شناسه ژانر")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenres", x => new { x.MovieId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_MovieGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "Entertainment",
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieGenres_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "Entertainment",
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Division",
                table: "CountryPartTypes",
                columns: new[] { "CountryPartTypeId", "CountryPartTypeName" },
                values: new object[,]
                {
                    { (byte)1, "کشور" },
                    { (byte)2, "استان" },
                    { (byte)3, "شهرستان" }
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

            migrationBuilder.InsertData(
                schema: "Shared",
                table: "Qualities",
                columns: new[] { "QualityId", "QualityName" },
                values: new object[,]
                {
                    { (byte)1, "2160" },
                    { (byte)2, "1080" },
                    { (byte)3, "720" },
                    { (byte)4, "480" }
                });

            migrationBuilder.InsertData(
                schema: "Shared",
                table: "QualityTypes",
                columns: new[] { "QualityTypeId", "QualityTypeName" },
                values: new object[,]
                {
                    { (byte)1, "BluRay" },
                    { (byte)2, "WebDl" }
                });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "ServerTypes",
                columns: new[] { "ServerTypeId", "ServerTypeName" },
                values: new object[,]
                {
                    { (byte)1, "People" },
                    { (byte)2, "Movie" },
                    { (byte)3, "UserMovie" }
                });

            migrationBuilder.InsertData(
                schema: "Shared",
                table: "Statuses",
                columns: new[] { "StatusId", "SatusName" },
                values: new object[,]
                {
                    { (byte)1, "درخواست" },
                    { (byte)2, "آرشیو" }
                });

            migrationBuilder.InsertData(
                schema: "Server",
                table: "Servers",
                columns: new[] { "ServerId", "Path", "ServerName", "ServerTypeId" },
                values: new object[,]
                {
                    { (byte)1, "Images/People", "PeoplePrimaryImage", (byte)1 },
                    { (byte)2, "Images/Movie", "MoviePrimaryImage", (byte)2 },
                    { (byte)3, "Images/UserMovie", "UserMoviePrimaryImage", (byte)3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryParts_CountryPartTypeId",
                schema: "Division",
                table: "CountryParts",
                column: "CountryPartTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_ServerId",
                schema: "Files",
                table: "Files",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_FileId",
                schema: "Entertainment",
                table: "Genres",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCompanies_CompanyId",
                schema: "Entertainment",
                table: "MovieCompanies",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCountries_CountryPartId",
                schema: "Entertainment",
                table: "MovieCountries",
                column: "CountryPartId");

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieFiles_FileId",
                schema: "Entertainment",
                table: "MovieFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_GenreId",
                schema: "Entertainment",
                table: "MovieGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieKeywords_KeywordId",
                schema: "Entertainment",
                table: "MovieKeywords",
                column: "KeywordId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLocations_MovieId",
                schema: "Entertainment",
                table: "MovieLocations",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_BudgetCurrencyId",
                schema: "Entertainment",
                table: "Movies",
                column: "BudgetCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CertificateId",
                schema: "Entertainment",
                table: "Movies",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CollectionId",
                schema: "Entertainment",
                table: "Movies",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieSpokenLanguages_LanguageId",
                schema: "Entertainment",
                table: "MovieSpokenLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieTaglines_MovieId",
                schema: "Entertainment",
                table: "MovieTaglines",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleFiles_FileId",
                schema: "Person",
                table: "PeopleFiles",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Peoples_DeathCauseId",
                schema: "Person",
                table: "Peoples",
                column: "DeathCauseId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_ServerTypeId",
                schema: "Server",
                table: "Servers",
                column: "ServerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_FormatId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieAudios_LanguageId",
                schema: "Managment",
                table: "UserMovieAudios",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieDisks_StatusId",
                schema: "Managment",
                table: "UserMovieDisks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieFile_FileId",
                schema: "Managment",
                table: "UserMovieFile",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieVideos_FormatId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieVideos_QualityId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "QualityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovieVideos_QualityTypeId",
                schema: "Managment",
                table: "UserMovieVideos",
                column: "QualityTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieCompanies",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "MovieCountries",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "MovieCredits",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "MovieFiles",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "MovieGenres",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "MovieKeywords",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "MovieLocations",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "MovieSpokenLanguages",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "MovieTaglines",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "PeopleFiles",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "UserMovieAudios",
                schema: "Managment");

            migrationBuilder.DropTable(
                name: "UserMovieDisks",
                schema: "Managment");

            migrationBuilder.DropTable(
                name: "UserMovieFile",
                schema: "Managment");

            migrationBuilder.DropTable(
                name: "UserMovieVideos",
                schema: "Managment");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "CountryParts",
                schema: "Division");

            migrationBuilder.DropTable(
                name: "CreditTypes",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "Keywords",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Peoples",
                schema: "Person");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Statuses",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Formats",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Movies",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "Qualities",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "QualityTypes",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "CountryPartTypes",
                schema: "Division");

            migrationBuilder.DropTable(
                name: "Files",
                schema: "Files");

            migrationBuilder.DropTable(
                name: "DeathCauses",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Certificates",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "Collections",
                schema: "Entertainment");

            migrationBuilder.DropTable(
                name: "Currencies",
                schema: "Shared");

            migrationBuilder.DropTable(
                name: "Servers",
                schema: "Server");

            migrationBuilder.DropTable(
                name: "ServerTypes",
                schema: "Server");
        }
    }
}
