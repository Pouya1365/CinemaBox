using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Json;
using System.Text;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class BudgetExtractor : IMovieGeneralInfoExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
       .GetPropertySafe("pageProps")?
       .GetPropertySafe("mainColumnData");
        model.Budget = data.GetPropertySafe("productionBudget").GetPropertySafe("budget").GetPropertySafe("amount")?.GetDouble();
        model.BudgetCurrency = data.GetPropertySafe("productionBudget").GetPropertySafe("budget").GetPropertySafe("currency")?.GetString();
        return model;
    }
}