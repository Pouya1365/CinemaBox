using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class LocationsExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("contentData");
        model.Locations = [];
        JsonElement.ArrayEnumerator? locations = data.GetPropertySafe("data").GetPropertySafe("title").GetPropertySafe("filmingLocations").GetPropertySafe("edges")?.EnumerateArray();
        model.Locations.AddRange(from location in locations.Value
                                 let html = location.GetProperty("node").GetProperty("text").GetString()
                                 where !string.IsNullOrWhiteSpace(html)
                                 let decoded = System.Net.WebUtility.HtmlDecode(html)
                                 select decoded);
        return model;
    }
}