using CinemaBox.Context.AppDbContext;
using CinemaBox.Scrapping.Interface.Imdb.Service;
using CinemaBox.Scrapping.Service.Movie;
using CinemaBox.Service.Division.CountryParts;
using CinemaBox.Service.Entertainment.Certificates;
using CinemaBox.Service.Entertainment.Coropration;
using CinemaBox.Service.Entertainment.Genres;
using CinemaBox.Service.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Entertainment.Link.MovieGenres;
using CinemaBox.Service.Entertainment.Link.MovieLocations;
using CinemaBox.Service.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Entertainment.Link.MovieTaglines;
using CinemaBox.Service.Entertainment.Movies;
using CinemaBox.Service.Interface.Division.CountryParts;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Coropration;
using CinemaBox.Service.Interface.Entertainment.Genres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCompanies;
using CinemaBox.Service.Interface.Entertainment.Link.MovieCountries;
using CinemaBox.Service.Interface.Entertainment.Link.MovieGenres;
using CinemaBox.Service.Interface.Entertainment.Link.MovieLocations;
using CinemaBox.Service.Interface.Entertainment.Link.MovieSpokenLanguages;
using CinemaBox.Service.Interface.Entertainment.Link.MovieTaglines;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.Service.Interface.Shared.Keywords;
using CinemaBox.Service.Interface.Shared.Languages;
using CinemaBox.Service.Shared.Currencies;
using CinemaBox.Service.Shared.Keywords;
using CinemaBox.Service.Shared.Languages;
using CinemaBox.UnitOfWork.Interface.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CinemaBox.Presentation;

internal static class Program
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
        Form1 mainForm =ServiceProviderServiceExtensions.GetRequiredService<Form1>(serviceProvider);

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
        services.AddScoped<IGenreServices,GenreServices>();
        services.AddScoped<IMovieGenreServices,MovieGenreServices>();
        services.AddScoped<ILanguageServices,LanguageServices>();
        services.AddScoped<IMovieSpokenLanguageServices, MovieSpokenLanguageServices>();
        services.AddScoped<IMovieTaglineServices, MovieTaglineServices>();
        services.AddScoped<IMovieLocationServices, MovieLocationServices>();
        services.AddScoped<IKeywordServices, KeywordServices>();

        // 📦 رجیستر کردن فرم‌ها
        services.AddTransient<Form1>();

        // 📁 هندل لود داینامیک DLL از پوشه libs
        AppDomain.CurrentDomain.AssemblyResolve += ResolveAssemblyFromLibs;

        return services;
    }

    /// <summary>
    /// لود داینامیک اسمبلی‌ها از مسیر libs
    /// </summary>
    private static Assembly? ResolveAssemblyFromLibs(object? sender, ResolveEventArgs args)
    {
        string dllName = new AssemblyName(args.Name).Name + ".dll";
        string dllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "libs", dllName);
        return File.Exists(dllPath) ? Assembly.LoadFrom(dllPath) : null;
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
