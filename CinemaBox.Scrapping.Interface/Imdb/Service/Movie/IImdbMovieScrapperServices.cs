using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Model.Entertainment.Movie.ShowMovie;

namespace CinemaBox.Scrapping.Interface.Imdb.Service.Movie;

public interface IImdbMovieScrapperServices
{
    Task<MovieModelScrapping> ImdbScrapperServicesAsync(string imdbId);
    Task<List<ShowMovieModel>> ImdbScrpperSearchServicesAsync(string movieName);
}
