using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class TaglinesExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
      .GetPropertySafe("pageProps")?
      .GetPropertySafe("contentData");
        model.Taglines = [];
        JsonElement.ArrayEnumerator? taglines = data.GetPropertySafe("data").GetPropertySafe("title").GetPropertySafe("taglines").GetPropertySafe("edges")?.EnumerateArray();
        model.Taglines.AddRange(from tagline in taglines.Value
                                let html = tagline.GetProperty("node").GetProperty("displayableProperty").GetProperty("value").GetProperty("plaidHtml").GetString()
                                where !string.IsNullOrWhiteSpace(html)
                                let decoded = System.Net.WebUtility.HtmlDecode(html)
                                select decoded);
        return model;
    }
}