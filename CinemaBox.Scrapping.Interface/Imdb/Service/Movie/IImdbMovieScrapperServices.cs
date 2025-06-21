using CinemaBox.Model.Imdb.Movie;

namespace CinemaBox.Scrapping.Interface.Imdb.Service.Movie;

public interface IImdbMovieScrapperServices
{
    Task<MovieModelScrapping> ImdbScrapperServicesAsync(string imdbId);
}
