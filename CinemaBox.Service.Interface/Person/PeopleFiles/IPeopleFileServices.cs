namespace CinemaBox.Service.Interface.Person.PeopleFiles;

public interface IPeopleFileServices
{
    Task CreateOrUpdatePeopleImage(string path, string imageUrl, string peopleId, string peopleName);

}
