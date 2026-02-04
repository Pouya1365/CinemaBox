using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class CountriesExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
       .GetPropertySafe("pageProps")?
       .GetPropertySafe("mainColumnData");
        // model.CountrieskeyValuePairs = [];
        // JsonElement? countries = data.GetPropertySafe("countriesDetails").GetPropertySafe("countries");
        // foreach ((string id, string text) in from JsonElement countryitem in countries.Value.EnumerateArray()
        //                                      let id = countryitem.GetProperty("id").GetString()
        //                                      where !string.IsNullOrEmpty(id)
        //                                      let text = countryitem.GetProperty("text").GetString()
        //                                      select (id, text))
        //     model.CountrieskeyValuePairs.Add(id, text);

        JsonElement? countries =
    data?
        .GetPropertySafe("countriesDetails")?
        .GetPropertySafe("countries");
        if (countries is not { ValueKind: JsonValueKind.Array })
            return model;

        model.CountrieskeyValuePairs = [];

        foreach (var (id, text) in
            from JsonElement country in countries.Value.EnumerateArray()
            let id = country.GetPropertySafe("id")?.GetString()
            let text = country.GetPropertySafe("text")?.GetString()
            where !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(text)
            select (id!, text!))
        {
            model.CountrieskeyValuePairs.Add(id, text);
        }
        return model;
    }
}