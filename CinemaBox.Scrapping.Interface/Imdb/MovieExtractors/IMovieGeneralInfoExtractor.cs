using CinemaBox.Model.Entertainment.Movie.Movie;

using System.Text.Json;

namespace CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;

public interface IMovieGeneralInfoExtractor
{
    MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json);



}
