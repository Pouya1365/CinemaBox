using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class AwardsExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
          .GetPropertySafe("pageProps")?
          .GetPropertySafe("mainColumnData");
        model.Winner = data.GetPropertySafe("wins").GetPropertySafe("total")?.GetInt64();
        model.Nomination = data.GetPropertySafe("nominationsExcludeWins").GetPropertySafe("total")?.GetInt64();
        model.TopRank = data.GetPropertySafe("ratingsSummary").GetPropertySafe("topRanking").GetPropertySafe("rank")?.GetInt32();
        model.OscarNominations = data.GetPropertySafe("prestigiousAwardSummary").GetPropertySafe("nominations")?.GetByte();
        model.OscarNominations = data.GetPropertySafe("prestigiousAwardSummary").GetPropertySafe("nominations")?.GetByte();
        model.OscarWins = data.GetPropertySafe("prestigiousAwardSummary").GetPropertySafe("wins")?.GetByte();
        return model;

    }
}