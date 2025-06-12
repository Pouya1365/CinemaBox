using CinemaBox.Model.Imdb.Movie;

namespace CinemaBox.Scrapping.Interface.Imdb.Service;

public interface IImdbMovieScrapperServices
{
    Task<MovieModelScrapping> ImdbScrapperServicesAsync(string imdbId);
}
