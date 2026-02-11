using System.Text.Json;
using CinemaBox.Model.Entertainment.Movie.ShowMovie;
namespace CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;

public interface IMovieSearchExtractor
{
    List<ShowMovieModel> Extract(JsonDocument json);
}
