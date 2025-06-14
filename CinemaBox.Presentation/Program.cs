using CinemaBox.Context.AppDbContext;
using CinemaBox.Scrapping.Interface.Imdb.Service;
using CinemaBox.Scrapping.Service.Movie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CinemaBox.Presentation;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.SetCompatibleTextRenderingDefault(false);

        // ساخت Container
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IImdbMovieScrapperServices, ImdbMovieScrapperServices>();

        AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            string dllName = new AssemblyName(assemblyName: args.Name).Name + ".dll";
            string dllPath = Path.Combine(path1: AppDomain.CurrentDomain.BaseDirectory, path2: "libs", path3: dllName);
            return File.Exists(dllPath) ? Assembly.LoadFrom(dllPath) : null;
        };
        // رجیستر کردن فرم به عنوان Transient (یا Singleton)
        serviceCollection.AddTransient<Form1>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        // اجرای فرم با سرویس‌های تزریق شده
        Form1 mainForm = ServiceProviderServiceExtensions.GetRequiredService<Form1>(serviceProvider);

        Application.Run(mainForm);
    }
    public class CinemaBoxDbContextFactory : IDesignTimeDbContextFactory<CinemaBoxDbContext>
    {
        public CinemaBoxDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CinemaBoxDbContext>();
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-SD5KJ4K;Database=TvTime;Trusted_Connection=True;TrustServerCertificate=True");
            return new CinemaBoxDbContext(optionsBuilder.Options);
        }
    }

}