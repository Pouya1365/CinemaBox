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
            .GetPropertySafe("aboveTheFoldData")
            .GetPropertySafe("releaseDate");
        JsonElement? yearElement = data.GetPropertySafe("year");
        model.ReleaseYear = (yearElement.HasValue && yearElement.Value.ValueKind == JsonValueKind.Number)
    ? yearElement.Value.GetInt64()
    : 0;
        JsonElement? monthElement = data.GetPropertySafe("month");
        model.ReleaseMonth = (monthElement.HasValue && monthElement.Value.ValueKind == JsonValueKind.Number)
            ? monthElement.Value.GetInt64()
            : 1;
        JsonElement? dayElement = data.GetPropertySafe("day");
        model.ReleaseDay = (dayElement.HasValue && dayElement.Value.ValueKind == JsonValueKind.Number)
            ? dayElement.Value.GetInt64()
            : 1;
        return model;
    }
}