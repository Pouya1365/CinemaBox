using CinemaBox.Domain.Person.Peoples;

namespace CinemaBox.Domain.Person.UserPeopleFiles;

public class UserPeopleFile
{
    public required byte UserId { get; set; }
    public required long PeopleId { get; set; }
    public required long PictureFileId { get; set; }
    public People? People { get; set; }
    public Files.Files.File? File { get; set; }
}