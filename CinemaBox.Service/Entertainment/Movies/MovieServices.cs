
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Model.Entertainment.Movie.ShowMovie;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Movies;

public class MovieServices(IUnitOfWork unitOfWork, ICertificateServices certificateServices, ICurrencyServices currencyServices) : IMovieServices
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    private readonly ICertificateServices _certificateServices = certificateServices ?? throw new ArgumentNullException(nameof(certificateServices));
    private readonly ICurrencyServices _currencyServices = currencyServices ?? throw new ArgumentNullException(nameof(currencyServices));
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
        List<ShowMovieModel> showMovieModels;
        IEnumerable<Movie> m = await _unitOfWork.Repository<Movie>().GetAllWithMultipleIncludesAsync(x => x.MovieFiles, x => x.File, x => x.Server);

        showMovieModels = [.. m.Select(x => new ShowMovieModel
        {
            EndYear=x.EndYear,
            EnTitle=x.EnTitle,
            FaTitle=x.FaTitle,
            MovieId=x.Id,
            StartYear=x.StartYear,
            PosterPath=Path.Combine( x.MovieFiles.FirstOrDefault()?.File.Server.Path,x.MovieFiles.FirstOrDefault().File.FileName)
        })];

        return showMovieModels;
    }




}