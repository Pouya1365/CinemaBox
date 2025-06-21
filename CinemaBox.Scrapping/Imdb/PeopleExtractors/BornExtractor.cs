using CinemaBox.Model.Imdb.People;
using CinemaBox.Scrapping.Interface.Imdb.PeopleExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CinemaBox.Scrapping.Imdb.PeopleExtractors;

public class BornExtractor : IPeopleGeneralInfoExtractor
{
    public PeopleModelScrapping Extract(PeopleModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props").GetPropertySafe("pageProps").GetPropertySafe("contentData");
        JsonElement? entityMetadata = data.GetPropertySafe("entityMetadata");
        JsonElement? nameData = data.GetPropertySafe("data").GetPropertySafe("name");
        model.BirthName = nameData.GetPropertySafe("birthName").GetPropertySafe("displayableProperty").GetPropertySafe("value").GetPropertySafe("plainText")?.GetString();
        model.BornDate = entityMetadata.GetPropertySafe("birthDate").GetPropertySafe("date")?.GetString();
        model.BornPlace = nameData.GetPropertySafe("birthLocation").GetPropertySafe("text")?.GetString();
        return model;
    }
}
