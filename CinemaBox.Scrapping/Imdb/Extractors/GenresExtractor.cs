using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.Extractors;

public class GenresExtractor : IGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
       .GetPropertySafe("pageProps")?
       .GetPropertySafe("aboveTheFoldData");
        model.Genres = [];
        JsonElement? genres = data.GetPropertySafe("genres").GetPropertySafe("genres") ?? default;
        model.Genres.AddRange(from JsonElement genreItem in genres.Value.EnumerateArray()
                              let text = genreItem.GetProperty("text").GetString()
                              where !string.IsNullOrEmpty(text)
                              select text);
        return model;
    }
}