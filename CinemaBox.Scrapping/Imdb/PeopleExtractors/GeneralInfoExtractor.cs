using CinemaBox.Model.Entertainment.People;
using CinemaBox.Scrapping.Interface.Imdb.PeopleExtractors;
using CinemaBox.Utilities.Json;
using System.Text.Json;

namespace CinemaBox.Scrapping.Imdb.PeopleExtractors;

public class GeneralInfoExtractor : IPeopleGeneralInfoExtractor
{
    public PeopleModelScrapping Extract(PeopleModelScrapping model, JsonDocument json)
    {
        JsonElement? data = json.RootElement.GetPropertySafe("props")?
            .GetPropertySafe("pageProps")?
            .GetPropertySafe("contentData")
            .GetPropertySafe("entityMetadata");
        JsonElement? nameData = data.GetPropertySafe("data").GetPropertySafe("name");
        model.EnFullName = data.GetPropertySafe("nameText").GetPropertySafe("text")?.GetString();
        model.Height = nameData.GetPropertySafe("height").GetPropertySafe("displayableProperty").GetPropertySafe("value").GetPropertySafe("plainText")?.GetString();
        model.EnMiniBiography = data.GetPropertySafe("bio").GetPropertySafe("text").GetPropertySafe("plainText")?.GetString();
        model.ImageUrl = data.GetPropertySafe("primaryImage").GetPropertySafe("url")?.GetString();
        return model;
    }
}