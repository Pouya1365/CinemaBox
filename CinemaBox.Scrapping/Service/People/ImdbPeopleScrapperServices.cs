using CinemaBox.Model.Entertainment.People.PeopleModelScrap;
using CinemaBox.Scrapping.Imdb.PeopleExtractors;
using CinemaBox.Scrapping.Interface.Imdb.PeopleExtractors;
using CinemaBox.Scrapping.Interface.Imdb.Service.People;
using CinemaBox.Utilities.Imdb.Json;
using CinemaBox.Utilities.Imdb.Url;
using CinemaBox.Utilities.Loader;
using System.Text.Json;

namespace CinemaBox.Scrapping.Service.People;

public class ImdbPeopleScrapperServices : IImdbPeopleScrapperServices
{
    private readonly HtmlLoader _htmlLoader;

    public ImdbPeopleScrapperServices(HtmlLoader htmlLoader)
    {
        _htmlLoader = htmlLoader;
    }

    public async Task<PeopleModelScrapping> ImdbPeopleScrapperServicesAsync(string imdbId)
    {
        var peopleModelScrapping = new PeopleModelScrapping
        {
            ImdbId = imdbId
        };

        var url = ImdbUrlBuilder.BuildNameUrl(
            imdbId: imdbId,
            path: "bio"
        );

        var jsonDocument = await LoadJsonDocumentAsync(url);

        if (jsonDocument is null)
            return peopleModelScrapping;

        List<IPeopleGeneralInfoExtractor> extractorsFromMainJson =
        [
            new GeneralInfoExtractor(),
            new BornExtractor(),
            new DeathExtractor(),
            new NickNameExtractor(),
        ];

        foreach (var extractor in extractorsFromMainJson)
        {
            peopleModelScrapping = extractor.Extract(
                model: peopleModelScrapping,
                json: jsonDocument
            );
        }

        return peopleModelScrapping;
    }

    private async Task<JsonDocument?> LoadJsonDocumentAsync(string url)
    {
        var document = await _htmlLoader.LoadDocumentAsync(url);

        if (document is null)
            return null;

        return NextDataJsonParser.Parse(document: document);
    }
}
