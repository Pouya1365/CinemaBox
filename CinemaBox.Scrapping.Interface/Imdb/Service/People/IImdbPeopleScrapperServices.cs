using CinemaBox.Model.Imdb.People;

namespace CinemaBox.Scrapping.Interface.Imdb.Service.People;

public interface IImdbPeopleScrapperServices
{
    Task<PeopleModelScrapping> ImdbPeopleScrapperServicesAsync(string imdbId);
}
