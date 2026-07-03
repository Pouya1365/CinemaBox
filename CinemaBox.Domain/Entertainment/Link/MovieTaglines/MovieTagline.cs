using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Link.MovieTaglines;

public class MovieTagline : PersistentObject<long>
{
    public required int MovieId { get; set; }
    public required string Tagline { get; set; }
    public string? PersianTagline { get; set; }
    public Movie? Movie { get; set; }
}