using CinemaBox.Model.Imdb.Movie;
using CinemaBox.Scrapping.Interface.Imdb.Extractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinamaBox.Scrapping.Imdb.Extractors;

public class BudgetExtractor : IGeneralInfoExtractor
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