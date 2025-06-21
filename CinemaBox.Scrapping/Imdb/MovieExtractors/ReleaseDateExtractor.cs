using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class ReleaseDateExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
            .GetPropertySafe("pageProps")?
            .GetPropertySafe("aboveTheFoldData");

        model.ReleaseYear = data.GetPropertySafe("releaseDate").GetPropertySafe("year")?.GetInt64() ?? 0;
        model.ReleaseMonth = data.GetPropertySafe("releaseDate").GetPropertySafe("month")?.GetInt64() ?? 0;
        model.ReleaseDay = data.GetPropertySafe("releaseDate").GetPropertySafe("day")?.GetInt64() ?? 0;
        return model;
    }
}