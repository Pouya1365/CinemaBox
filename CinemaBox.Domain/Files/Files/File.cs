using CinemaBox.Domain.Entertainment.Genres;
using CinemaBox.Domain.Entertainment.Link.MovieFiles;
using CinemaBox.Domain.Managment.Link.UserMovieFiles;
using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Person.PeopleFiles;
using CinemaBox.Domain.Servers.Servers;
namespace CinemaBox.Domain.Files.Files;

public class File : PersistentObject<long>
{
    public required byte ServerId { get; set; }

    public string? FileName { get; set; }
    public Server? Server { get; set; }
    public ICollection<PeopleFile> PeopleFiles { get; set; } = [];
    public ICollection<MovieFile> MovieFiles { get; set; } = [];
    public ICollection<Genre> Genres { get; set; } = [];
    public ICollection<UserMovieFile> UserMovieFile { get; set; } = [];
}