using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Managment.Link.UserMovieFiles;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Model.Entertainment.Movie.ShowMovie;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Managment.Link.UserMovieFiles;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.Service.Managment.Link.UserMovieFiles;
using CinemaBox.UnitOfWork.Interface.UOW;
using System.Collections.Generic;

namespace CinemaBox.Service.Entertainment.Movies;

public class MovieServices(IUnitOfWork unitOfWork, ICertificateServices certificateServices, ICurrencyServices currencyServices, IUserMovieFileServices userMovieFileServices) : IMovieServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ICertificateServices _certificateServices = certificateServices ?? throw new ArgumentNullException(nameof(certificateServices));
    private readonly ICurrencyServices _currencyServices = currencyServices ?? throw new ArgumentNullException(nameof(currencyServices));
    private readonly IUserMovieFileServices _userMovieFileServices = userMovieFileServices ?? throw new ArgumentNullException(nameof(userMovieFileServices));
    public async Task<Movie> CreateOrUpdate(MovieModelScrapping model)
    {
        byte? certificateId = await GetCertificateIdAsync(model.Certificate);
        byte? currencyId = await GetCurrencyIdAsync(model.BudgetCurrency);
        Movie? movie = await GeMovieAsync(model.ImdbId);
        bool isNew = movie.EnTitle != null;
        UpdateMovieFields(movie, model, certificateId, currencyId);
        if (isNew == true)
            _unitOfWork.Repository<Movie>().Update(movie);
        else
            await _unitOfWork.Repository<Movie>().AddAsync(movie);
        await _unitOfWork.CompleteAsync();
        return movie;
    }
    private async Task<byte?> GetCertificateIdAsync(string? certificate) => certificate != null
            ? (await _certificateServices.CreateOrGetCertificateAsync(certificate))?.Id
            : null;
    private async Task<byte?> GetCurrencyIdAsync(string? currency) => currency != null
            ? (await _currencyServices.CreateOrGetCurrencyAsync(currency))?.Id
            : null;
    public async Task<Movie?> GeMovieAsync(string? ImdbId) => ImdbId != null
            ? await _unitOfWork.Repository<Movie>().FindAsync(x => x.Id == ImdbId) ?? new Movie { Id = ImdbId } : new Movie { Id = ImdbId };
    private void UpdateMovieFields(Movie movie, MovieModelScrapping model, byte? certificateId, byte? currencyId)
    {
        movie.CertificateId = certificateId;
        movie.BudgetCurrencyId = currencyId;
        movie.ReleaseDay = model.ReleaseDay;
        movie.AggregateRating = model.AggregateRating;
        movie.Budget = model.Budget;
        movie.EnPlot = model.EnPlot;
        movie.EnStoryline = model.EnStoryline;
        movie.EnTitle = model.EnTitle;
        movie.Nomination = model.Nomination;
        movie.OriginalTitle = model.OriginalTitle;
        movie.Winner = model.Winner;
        movie.VoteCount = model.VoteCount;
        movie.StartYear = model.StartYear;
        movie.RunTimeMinutes = model.RunTimeMinutes;
        movie.ReleaseYear = model.ReleaseYear;
        movie.ReleaseMonth = model.ReleaseMonth;
        movie.TopRank = model.TopRank;
        movie.OscarNominations = model.OscarNominations;
        movie.OscarWins = model.OscarWins;
    }
    public async Task<List<ShowMovieModel>> GetMovieModelsAsync(string search)
    {
        // 1. بارگذاری فیلم‌ها همراه با فایل‌ها و سرورهای مرتبط
        IEnumerable<Movie> movies = await LoadMoviesAsync();

        // 2. بارگذاری فایل‌های کاربر برای فیلم‌ها
        IEnumerable<UserMovieFile> userMovieFiles = await GetUserMovieFilesAsync();

        // 3. فیلتر کردن فیلم‌ها بر اساس جستجو (اختیاری)
        if (!string.IsNullOrWhiteSpace(search))
        {
            int.TryParse(search, out int idSearch);
            movies = movies.Where(m =>
                (!string.IsNullOrEmpty(m.EnTitle) && m.EnTitle.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(m.FaTitle) && m.FaTitle.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                m.Id == search || // یا Guid بسته به نوع
                (!string.IsNullOrEmpty(m.EnPlot) && m.EnPlot.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(m.FaStoryline) && m.FaStoryline.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(m.EnStoryline) && m.EnStoryline.Contains(search, StringComparison.OrdinalIgnoreCase)) ||
                m.StartYear.ToString() == search ||
                m.EndYear.ToString() == search
            );

        }


        // 4. تبدیل لیست فایل‌های کاربر به دیکشنری
        Dictionary<string, UserMovieFile> userFilesDict = ToMovieUserFileDictionary(userMovieFiles);

        // 5. ساخت مدل نهایی برای نمایش
        List<ShowMovieModel> showMovieModels = [.. movies.Select(movie =>
            CreateShowMovieModel(movie, userFilesDict))];

        return showMovieModels;
    }

    // بارگذاری فیلم‌ها با فایل‌ها و سرورهای مرتبط
    private async Task<IEnumerable<Movie>> LoadMoviesAsync() => await _unitOfWork.Repository<Movie>().GetAllWithMultipleIncludesAsync(
            x => x.MovieFiles,
            x => x.File,
            x => x.Server
        );


    // بارگذاری فایل‌های کاربر
    private async Task<IEnumerable<UserMovieFile>> GetUserMovieFilesAsync() =>
     await GetUserMovieFiles();

    // تبدیل لیست فایل‌های کاربر به دیکشنری برای دسترسی سریع
    private Dictionary<string, UserMovieFile> ToMovieUserFileDictionary(IEnumerable<UserMovieFile> files) => files
            .Where(f => f.File?.Server != null)
            .GroupBy(f => f.MovieId)
            .ToDictionary(g => g.Key, g => g.First());

    // ساخت مدل نهایی برای هر فیلم
    private ShowMovieModel CreateShowMovieModel(Movie movie, Dictionary<string, UserMovieFile> userFiles)
    {
        string imageUrl;

        // اگر فایل کاربر برای فیلم موجود بود
        if (userFiles.TryGetValue(movie.Id, out var userFile))
            imageUrl = Path.Combine(userFile.File.Server.Path, userFile.File.FileName);

        else
        {
            // اگر فایل کاربر نبود، از فایل پیش‌فرض فیلم استفاده می‌کنیم
            Domain.Entertainment.Link.MovieFiles.MovieFile? defaultFile = movie.MovieFiles
                .FirstOrDefault(f => f.File?.Server != null);

            imageUrl = defaultFile != null
                ? Path.Combine(defaultFile.File.Server.Path, defaultFile.File.FileName)
                : null;
        }

        return new ShowMovieModel
        {
            MovieId = movie.Id,
            EnTitle = movie.EnTitle,
            FaTitle = movie.FaTitle,
            StartYear = movie.StartYear,
            EndYear = movie.EndYear,
            PosterPath = imageUrl
        };
    }

    public async Task UpdateMovie(Movie movie)
    {
        _unitOfWork.Repository<Movie>().Update(movie);
        await _unitOfWork.CompleteAsync();
    }
    public async Task<IEnumerable<UserMovieFile>> GetUserMovieFiles() => await _userMovieFileServices.GetAllUserMovieFile();


}