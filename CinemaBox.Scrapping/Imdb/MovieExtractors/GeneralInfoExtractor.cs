using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class GeneralInfoExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
            .GetPropertySafe("pageProps")?
            .GetPropertySafe("aboveTheFoldData");
        model.EnTitle = data?.GetPropertySafe("titleText")?.GetPropertySafe("text")?.GetString();
        model.OriginalTitle = data?.GetPropertySafe("originalTitleText")?.GetPropertySafe("text")?.GetString();
        model.StartYear = data?.GetPropertySafe("releaseYear")?.GetPropertySafe("year")?.GetInt64() ?? 0;
        long? seconds = data?.GetPropertySafe("runtime")?.GetPropertySafe("seconds")?.GetInt64();
        model.RunTimeMinutes = seconds.HasValue ? seconds.Value / 60 : 0;
        model.ImageUrl = data?.GetPropertySafe("primaryImage")?.GetPropertySafe("url")?.GetString();
        return model;
    }
}