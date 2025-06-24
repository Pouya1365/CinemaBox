using CinemaBox.Domain.Person.PeopleFiles;

namespace CinemaBox.Service.Interface.Person.PeopleFiles;

public interface IPeopleFileServices
{
    Task CreateOrUpdatePeopleImage(string path, string imageUrl, string peopleId, string peopleName);
    Task<IEnumerable<PeopleFile?>> GetPeopleFile(List<string> peopleIds);
    Task<PeopleFile?> GetPeopleFileWitInclude(string peopleId);

}
