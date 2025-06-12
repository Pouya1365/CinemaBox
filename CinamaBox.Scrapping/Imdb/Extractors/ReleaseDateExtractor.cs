using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinamaBox.Scrapping.Imdb.Extractors;

public class  ReleaseDateExtractor: IGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
            .GetPropertySafe("pageProps")?
            .GetPropertySafe("aboveTheFoldData");

        model.ReleaseYear = data.GetPropertySafe("releaseDate").GetPropertySafe("year")?.GetInt64()??0;
        model.ReleaseMonth = data.GetPropertySafe("releaseDate").GetPropertySafe("month")?.GetInt64()??0;
        model.ReleaseDay = data.GetPropertySafe("releaseDate").GetPropertySafe("day")?.GetInt64()??0;
        return model;

    }
}
