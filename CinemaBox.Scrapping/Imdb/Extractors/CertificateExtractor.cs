using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.Extractors;

public class CertificateExtractor : IGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("aboveTheFoldData");
        model.Certificate = data.GetPropertySafe("certificate").GetPropertySafe("rating")?.GetString();
        return model;

    }
}