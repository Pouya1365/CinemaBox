using CinemaBox.Model.Imdb.Movie;
using System.Text.Json;

namespace CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;

public interface IMovieGeneralInfoExtractor
{
    MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json);
    
}
