using CinemaBox.Context.AppDbContext;
using CinemaBox.Scrapping.Interface.Imdb.Service.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Service.People;
using CinemaBox.Scrapping.Service.Movie;
using CinemaBox.Scrapping.Service.People;
using CinemaBox.Service.Division.CountryParts;
using CinemaBox.Service.Entertainment.Certificates;
using CinemaBox.Service.Entertainment.Collections;
using CinemaBox.Service.Entertainment.Coropration;
using CinemaBox.Service.Entertainment.Genres;
using CinemaBox.Service.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Entertainment.Link.MovieCredits;
using CinemaBox.Service.Entertainment.Link.MovieFiles;
using CinemaBox.Service.Entertainment.Link.MovieGenres;
using CinemaBox.Service.Entertainment.Link.MovieKeywords;
using CinemaBox.Service.Entertainment.Link.MovieLocations;
using CinemaBox.Service.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Entertainment.Link.MovieTaglines;
using CinemaBox.Service.Entertainment.Movies;
using CinemaBox.Service.Files.Files;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Collections;
using CinemaBox.Service.Interface.Entertainment.Coropration;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCredits;
using CinemaBox.Service.Interface.Entertainment.Link.MovieFiles;
using CinemaBox.Service.Interface.Entertainment.Link.MovieGenres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieKeywords;
using CinemaBox.Service.Interface.Entertainment.Link.MovieLocations;
using CinemaBox.Service.Interface.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Interface.Entertainment.Link.MovieTaglines;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Files.Files;
using CinemaBox.Service.Interface.Managment.Link.UserMovieAudios;
using CinemaBox.Service.Interface.Managment.Link.UserMovieDisks;
using CinemaBox.Service.Interface.Managment.Link.UserMovieFiles;
using CinemaBox.Service.Interface.Managment.Link.UserMovieVideos;
using CinemaBox.Service.Interface.Person.PeopleFiles;
using CinemaBox.Service.Interface.Person.Peoples;
using CinemaBox.Service.Interface.Servers.Servers;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.Service.Interface.Shared.DeathCauses;
using CinemaBox.Service.Interface.Shared.Formats;
using CinemaBox.Service.Interface.Shared.Keywords;
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.Service.Interface.Shared.Qualities.Qualities;
using CinemaBox.Service.Interface.Shared.Qualities.QualityTypes;
using CinemaBox.Service.Interface.Shared.Statuses;
using CinemaBox.Service.Managment.Link.UserMovieAudios;
using CinemaBox.Service.Managment.Link.UserMovieDisks;
using CinemaBox.Service.Managment.Link.UserMovieFiles;
using CinemaBox.Service.Managment.Link.UserMovieVideos;
using CinemaBox.Service.Person.PeopleFiles;
using CinemaBox.Service.Person.Peoples;
using CinemaBox.Service.Servers.Servers;
using CinemaBox.Service.Shared.Currencies;
using CinemaBox.Service.Shared.DeathCauses;
using CinemaBox.Service.Shared.Formats;
using CinemaBox.Service.Shared.Keywords;
using CinemaBox.Service.Shared.Languages;
using CinemaBox.Service.Shared.Qualities.Qualities;
using CinemaBox.Service.Shared.Qualities.QualityTypes;
using CinemaBox.Service.Shared.Statuses;
using CinemaBox.UnitOfWork.Interface.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace CinemaBox.Presentation;

 static class Program
{
    [STAThread]
    static void Main()
    {

        ApplicationConfiguration.Initialize();
        Application.SetCompatibleTextRenderingDefault(false);

        // سرویس‌ها
        IServiceCollection serviceCollection = ConfigureServices();
        ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


        // اجرای فرم اصلی
        Frm_Movie mainForm = ServiceProviderServiceExtensions.GetRequiredService<Frm_Movie>(serviceProvider);

        Application.Run(mainForm);
    }

    /// <summary>
    /// پیکربندی سرویس‌ها و DI
    /// </summary>
    private static IServiceCollection ConfigureServices()
    {
        ServiceCollection services = new();

        // 🔧 اتصال به دیتابیس
        const string connectionString = @"Server=DESKTOP-SD5KJ4K;Database=TvTime;Trusted_Connection=True;TrustServerCertificate=True";
        services.AddDbContext<CinemaBoxDbContext>(options =>
            options.UseSqlServer(connectionString));

        // 🧠 سرویس‌ها (Scoped برای DbContext وابسته)
        services.AddScoped<IImdbMovieScrapperServices, ImdbMovieScrapperServices>();
        services.AddScoped<IUnitOfWork, UnitOfWork.UOW.UnitOfWork>();
        services.AddScoped<IMovieServices, MovieServices>();
        services.AddScoped<ICurrencyServices, CurrencyServices>();
        services.AddScoped<ICertificateServices, CertificateServices>();
        services.AddScoped<ICompanyServices, CompanyServices>();
        services.AddScoped<IMovieCompanyServices, MovieCompanyServices>();
        services.AddScoped<ICountryPartServices, CountryPartServices>();
        services.AddScoped<IMovieCountryServices, MovieCountryServices>();
        services.AddScoped<IGenreServices, GenreServices>();
        services.AddScoped<IMovieGenreServices, MovieGenreServices>();
        services.AddScoped<ILanguageServices, LanguageServices>();
        services.AddScoped<IMovieSpokenLanguageServices, MovieSpokenLanguageServices>();
        services.AddScoped<IMovieTaglineServices, MovieTaglineServices>();
        services.AddScoped<IMovieLocationServices, MovieLocationServices>();
        services.AddScoped<IKeywordServices, KeywordServices>();
        services.AddScoped<IMovieKeywordServices, MovieKeywordServices>();
        services.AddScoped<IImdbPeopleScrapperServices, ImdbPeopleScrapperServices>();
        services.AddScoped<IMovieCreditServices, MovieCreditServices>();
        services.AddScoped<IPeopleServices, PeopleServices>();
        services.AddScoped<IDeathCauseServices, DeathCauseServices>();
        services.AddScoped<IPeopleFileServices, PeopleFileServices>();
        services.AddScoped<IServerServices, ServerServices>();
        services.AddScoped<IFileServices, FileServices>();
        services.AddScoped<IMovieFileServices, MovieFileServices>();
        services.AddScoped<IUserMovieDiskServices, UserMovieDiskServices>();
        services.AddScoped<IUserMovieVideoServices, UserMovieVideoServices>();
        services.AddScoped<IStatusServices, StatusServices>();
        services.AddScoped<IFormatServices, FormatServices>();
        services.AddScoped<IUserMovieAudioServices, UserMovieAudioServices>();
        services.AddScoped<IUserMovieFileServices, UserMovieFileServices>();
        services.AddScoped<ICollectionServices, CollectionServices>();
        services.AddScoped<IQualityServices, QualityServices>();
        services.AddScoped<IQualityTypeServices, QualityTypeServices>();
        services.AddScoped<IImdbOtherScrapperServices, ImdbOtherScrapperServices>();
        // 📦 رجیستر کردن فرم‌ها
        services.AddTransient<Frm_Movie>();

        // 📁 هندل لود داینامیک DLL از پوشه libs
   

        return services;
    }


    /// <summary>
    /// برای EF Core Migration استفاده می‌شود
    /// </summary>
    public class CinemaBoxDbContextFactory : IDesignTimeDbContextFactory<CinemaBoxDbContext>
    {
        public CinemaBoxDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<CinemaBoxDbContext> optionsBuilder = new DbContextOptionsBuilder<CinemaBoxDbContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SD5KJ4K;Database=TvTime;Trusted_Connection=True;TrustServerCertificate=True");
            return new CinemaBoxDbContext(optionsBuilder.Options);
        }
    }
}
