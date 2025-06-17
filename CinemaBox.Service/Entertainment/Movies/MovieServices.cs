using CinemaBox.Domain.Entertainment.Certificates;
using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Service.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Certificates;
using CinemaBox.Service.Interface.Entertainment.Movies;
using CinemaBox.Service.Interface.Shared.Currencies;
using CinemaBox.UnitOfWork.Interface.UOW;

namespace CinemaBox.Service.Entertainment.Movies;

public class MovieServices(IUnitOfWork unitOfWork, ICertificateServices certificateServices,ICurrencyServices currencyServices) : IMovieServices
{
    public async Task<Movie> CreateOrUpdate(MovieModelScrapping model)
    {
        byte? certificateId = await GetCertificateIdAsync(model.Certificate);
        byte? currencyId = await GetCurrencyIdAsync(model.BudgetCurrency);
        var movie = await GeMovieAsync(model.ImdbId);
        UpdateMovieFields(movie, model, certificateId, currencyId);
        if (movie.Id == model.ImdbId)        
            unitOfWork.Movies.Update(movie);       
        else
            await unitOfWork.Movies.AddAsync(movie);
       await unitOfWork.CompleteAsync();        
        return movie;
    }
    private async Task<byte?> GetCertificateIdAsync(string? certificate) => certificate != null
            ? (await certificateServices.CreateOrGetCertificateAsync(certificate))?.Id
            : null;
    private async Task<byte?> GetCurrencyIdAsync(string? currency)=> currency != null
            ? (await  currencyServices.CreateOrGetCurrencyAsync(currency))?.Id
            : null;
    public async Task<Movie?> GeMovieAsync(string? ImdbId) => ImdbId != null
            ? await unitOfWork.Movies.FindAsync(x => x.Id == ImdbId) : new Movie {Id=ImdbId };
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
}