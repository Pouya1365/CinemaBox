using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Link.MovieTaglines;

public class MovieTagline : PersistentObject<long>
{
    public required string MovieId { get; set; }
    public required string EnTagline { get; set; }
    public string? FaTagline { get; set; }
    public Movie? Movie { get; set; }
}