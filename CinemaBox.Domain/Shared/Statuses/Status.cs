using CinemaBox.Domain.Persistent;
using CinemaBox.Domain.Users.Link.UserMovieDisks;
namespace CinemaBox.Domain.Shared.Statuses;
public class Status : PersistentObject<byte>
{
    public required string SatusName { get; set; }
    public ICollection<UserMovieDisk> UserMovieDisks { get; set; } = [];
}
