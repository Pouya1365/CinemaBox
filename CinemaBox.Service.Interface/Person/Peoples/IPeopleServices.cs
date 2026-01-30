using CinemaBox.Domain.Person.Peoples;
using CinemaBox.Model.Entertainment.Cast.Credit;
using CinemaBox.Model.Entertainment.People.ShowPeople;

namespace CinemaBox.Service.Interface.Person.Peoples;

public interface IPeopleServices
{
    Task<People> CreateOrUpdatePeople(CreditModel creditModel, string path);
    Task<People> GetPeople(string peopleId);
    Task<List<People>?> GetPeopleFaNull();
    Task UpdateFaPeople(List<People> peoples);
    Task<IEnumerable<ShowPeopleModel>> GetAllPeopleModel(string search);
    Task<People> UpdatePeople(string imdbId, string path);
}
