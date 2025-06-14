using CinemaBox.Domain.Person.Peoples;

namespace CinemaBox.Domain.Person.PeopleFiles;

public class PeopleFile
{
    public required string PeopleId { get; set; }
    public required long FileId { get; set; }
    public People? People { get; set; }
    public Files.Files.File? File { get; set; }
}