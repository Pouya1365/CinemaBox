using CinemaBox.Model.Entertainment.People;
using CinemaBox.Scrapping.Interface.Imdb.PeopleExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.PeopleExtractors;

public class DeathExtractor : IPeopleGeneralInfoExtractor
{
    public PeopleModelScrapping Extract(PeopleModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props").GetPropertySafe("pageProps").GetPropertySafe("contentData");
        JsonElement? entityMetadata = data.GetPropertySafe("entityMetadata");
        JsonElement? nameData = data.GetPropertySafe("data").GetPropertySafe("name");
        model.DeathDate = entityMetadata.GetPropertySafe("deathDate").GetPropertySafe("date")?.GetString();
        model.DeathPlace = nameData.GetPropertySafe("deathLocation").GetPropertySafe("text")?.GetString();
        model.DeathCause = nameData.GetPropertySafe("deathCause").GetPropertySafe("displayableProperty").GetPropertySafe("value").GetPropertySafe("plaidHtml")?.GetString();
        return model;
    }
}