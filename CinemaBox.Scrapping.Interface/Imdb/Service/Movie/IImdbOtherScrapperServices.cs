using CinemaBox.Model.Entertainment.Movie.Movie;

namespace CinemaBox.Scrapping.Interface.Imdb.Service.Movie;

public interface IImdbOtherScrapperServices
{
    Task<MovieModelScrapping> ImdbScrapperServicesAsync(MovieModelScrapping movieModel);
}
