using CinemaBox.Model.Entertainment.People;
using System.Text.Json;

namespace CinemaBox.Scrapping.Interface.Imdb.PeopleExtractors;

public interface IPeopleGeneralInfoExtractor
{
    PeopleModelScrapping Extract(PeopleModelScrapping model, JsonDocument json);
}
