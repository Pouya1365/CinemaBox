using CinemaBox.Domain.Entertainment.Movies;
using CinemaBox.Domain.Persistent;

namespace CinemaBox.Domain.Entertainment.Link.MovieLocations;

public class MovieLocation : PersistentObject<int>
{
    public required int MovieId { get; set; }
    public required string LocationName { get; set; }
    public Movie? Movie { get; set; }
}