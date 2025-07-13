using CinemaBox.Model.Entertainment.People.PeopleModelScrap;
using CinemaBox.Scrapping.Interface.Imdb.PeopleExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.PeopleExtractors;

public class NickNameExtractor : IPeopleGeneralInfoExtractor
{
    public PeopleModelScrapping Extract(PeopleModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props").GetPropertySafe("pageProps").GetPropertySafe("contentData");
        JsonElement? nickNames = data.GetPropertySafe("data").GetPropertySafe("name").GetPropertySafe("nickNames");
        if (nickNames.HasValue &&
     nickNames.Value.ValueKind == JsonValueKind.Array &&
     nickNames.Value.GetArrayLength() > 0)
            model.NickName = nickNames.Value[0].GetPropertySafe("displayableProperty").GetPropertySafe("value").GetPropertySafe("plainText")?.GetString();
        return model;
    }
}