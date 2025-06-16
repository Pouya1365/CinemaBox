using CinemaBox.Domain.Managment.Link.UserMovieDisks;
using CinemaBox.Domain.Persistent;
namespace CinemaBox.Domain.Shared.Statuses;
public class Status : PersistentObject<byte>
{
    public required string SatusName { get; set; }
    public ICollection<UserMovieDisk> UserMovieDisks { get; set; } = [];
}
